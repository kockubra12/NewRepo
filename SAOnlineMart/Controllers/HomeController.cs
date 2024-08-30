using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Models;
using SAOnlineMart.Services;
using System.Linq;

namespace SAOnlineMart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        private readonly CartService _cartService;

        public HomeController(ProductService productService, CartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        // Home page showing the list of products
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        // Product detail page
        public IActionResult ProductDetail(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // Add product to the cart
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.GetProductById(productId);
            if (product != null && quantity > 0)
            {
                _cartService.AddToCart(product, quantity);

                // Debugging line to verify cart contents
                Console.WriteLine($"Added to cart: Product ID {productId}, Quantity {quantity}");
            }

            return RedirectToAction("Cart");
        }


        // View cart items
        public IActionResult Cart()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }

        // Remove product from the cart
        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("Cart");
        }

        // Update product quantity in the cart
        [HttpPost]
        public IActionResult UpdateQuantity(Dictionary<int, int> quantities)
        {
            foreach (var quantity in quantities)
            {
                int productId = quantity.Key;
                int quantityValue = quantity.Value;

                if (quantityValue > 0)
                {
                    _cartService.UpdateQuantity(productId, quantityValue);
                }
            }

            return RedirectToAction("Cart");
        }

        // Checkout page
        public IActionResult Checkout()
        {
            var cartItems = _cartService.GetCartItems();

            // Debugging line to verify cartItems content
            Console.WriteLine($"Cart items count: {cartItems?.Count()}");

            // Ensure cartItems is not null and is correctly populated
            if (cartItems == null || !cartItems.Any())
            {
                // Optionally, log or handle the empty cart case here
                return View(new CheckoutViewModel
                {
                    CartItems = Enumerable.Empty<CartItem>(),
                    TotalAmount = 0,
                    ShippingAddress = string.Empty,
                    PaymentMethod = string.Empty
                });
            }

            var totalAmount = cartItems.Sum(ci => ci.Product.Price * ci.Quantity);

            var model = new CheckoutViewModel
            {
                CartItems = cartItems,
                TotalAmount = totalAmount,
                ShippingAddress = string.Empty,
                PaymentMethod = string.Empty
            };

            return View(model);
        }




        // Complete the purchase
        [HttpPost]
        public IActionResult CompletePurchase(CheckoutViewModel model)
        {
            if (ModelState.IsValid)
            {
            

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the checkout page
            return View("Checkout", model);
        }
    }
}
