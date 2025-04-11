using System.ComponentModel.DataAnnotations.Schema;

namespace WedBanHang.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.DangXuLy;
        public PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; } // ✅ Đúng cách ánh xạ

        public List<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatus
    {
        DangXuLy,
        DaGiao,
        DaHuy
    }

    public enum PaymentMethod
    {
        COD,
        BankTransfer
    }
}

