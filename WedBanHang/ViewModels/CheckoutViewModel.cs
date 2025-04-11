using WedBanHang.Models;

namespace WedBanHang.ViewModels
{
    public class CheckoutViewModel
    {
        public string ShippingAddress { get; set; }
        public string Notes { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
