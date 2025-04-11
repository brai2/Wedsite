using WedBanHang.Models;
using System.Text.Json;


public class CartService : ICartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string CartSessionKey = "CartSession";

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private List<CartItem> GetSessionCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartJson = session.GetString(CartSessionKey);
        return string.IsNullOrEmpty(cartJson)
            ? new List<CartItem>()
            : JsonSerializer.Deserialize<List<CartItem>>(cartJson);
    }

    private void SaveSessionCart(List<CartItem> cart)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
    }

    public void AddToCart(Product product, int quantity)
    {
        var cart = GetSessionCart();
        var item = cart.FirstOrDefault(i => i.ProductId == product.Id);

        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            cart.Add(new CartItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity,
                ImageUrl = product.ImageUrl
            });
        }

        SaveSessionCart(cart);
    }

    public void RemoveFromCart(int productId)
    {
        var cart = GetSessionCart();
        var item = cart.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            cart.Remove(item);
            SaveSessionCart(cart);
        }
    }

    public void ClearCart()
    {
        SaveSessionCart(new List<CartItem>());
    }

    public List<CartItem> GetCartItems()
    {
        return GetSessionCart();
    }

    public decimal GetCartTotal()
    {
        return GetSessionCart().Sum(i => i.Price * i.Quantity); // hoặc i.TotalPrice nếu đã có
    }
}

