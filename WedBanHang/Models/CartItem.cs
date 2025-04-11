namespace WedBanHang.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  // Đơn giá (UnitPrice)
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }

        // ✅ Tính tổng tiền cho sản phẩm này
        public decimal TotalPrice => Price * Quantity;
    }
}

