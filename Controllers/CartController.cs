// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using SAOnlineMartAPI.Models;
using SAOnlineMartAPI.DTOs;
using System.Linq;

namespace SAOnlineMartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCartItems()
        {
            var cartItems = _context.CartItems.ToList();
            return Ok(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(CartItemDto cartItemDto)
        {
            var product = _context.Products.Find(cartItemDto.ProductId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            var cartItem = new CartItem
            {
                Product = product,
                Quantity = cartItemDto.Quantity
            };

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return Ok(cartItem);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound("Cart item not found");
            }

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
