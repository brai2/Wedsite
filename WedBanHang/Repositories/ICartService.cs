using WedBanHang.Models;

public interface ICartService
{
    void AddToCart(Product product, int quantity);
    void RemoveFromCart(int productId);
    void ClearCart();
    List<CartItem> GetCartItems();
    decimal GetCartTotal();
}

