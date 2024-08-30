using System.Collections.Generic;
using System.Linq;
using SAOnlineMart.Models;

namespace SAOnlineMart.Services
{
    public class CartService
    {
        // Sepet ürünlerini bellekte tutar
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public void AddToCart(Product product, int quantity)
        {
            // Ürün zaten sepet içinde varsa miktarı güncelle
            var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                // Ürün sepet içinde değilse yeni bir eleman ekle
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            // Sepet içeriğini kontrol et
            Console.WriteLine($"CartItems count in GetCartItems: {_cartItems?.Count()}");
            return _cartItems ?? Enumerable.Empty<CartItem>();
        }

        public void RemoveFromCart(int productId)
        {
            // Sepetten ürün çıkar
            var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            // Sepetteki ürünün miktarını güncelle
            var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
        }

        public void ClearCart()
        {
            // Sepeti temizle
            _cartItems.Clear();
        }
    }
}
