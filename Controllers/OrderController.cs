// Controllers/OrderController.cs
using Microsoft.AspNetCore.Mvc;
using SAOnlineMartAPI.Models;
using System.Linq;

namespace SAOnlineMartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CompleteOrder()
        {
            var cartItems = _context.CartItems.ToList();
            if (!cartItems.Any())
            {
                return BadRequest("Cart is empty");
            }

            // Here you would typically handle order processing and payment.
            // For simplicity, we're just clearing the cart.

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();

            return Ok("Order completed successfully");
        }
    }
}
