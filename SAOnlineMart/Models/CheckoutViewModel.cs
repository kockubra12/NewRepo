using System.Collections.Generic;

namespace SAOnlineMart.Models
{
    public class CheckoutViewModel
    {
        public IEnumerable<CartItem> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
    }
}
