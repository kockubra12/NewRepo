// Controllers/AdminController.cs
using Microsoft.AspNetCore.Mvc;
using SAOnlineMartAPI.DTOs;
using SAOnlineMartAPI.Models;
using System.Linq;

namespace SAOnlineMartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all products
        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // Get product by ID
        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Create a new product
        [HttpPost("products")]
        public IActionResult CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Update an existing product
        [HttpPut("products/{id}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;

            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        // Delete a product
        [HttpDelete("products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
