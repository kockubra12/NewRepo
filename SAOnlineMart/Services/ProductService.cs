// Services/ProductService.cs
using SAOnlineMart.Models;
using System.Collections.Generic;
using System.Linq;

namespace SAOnlineMart.Services
{
    public class ProductService
    {
        
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Handcrafted Necklace", Description = "Beautiful handmade necklace", Price = 150.00m },
            new Product { Id = 2, Name = "Local T-shirt", Description = "Comfortable and stylish t-shirt", Price = 100.00m },
            new Product { Id = 3, Name = "Wooden Bowl", Description = "Handcrafted wooden bowl", Price = 75.00m }
        };

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
