// Controllers/AdminController.cs
using Microsoft.AspNetCore.Mvc;
using SAOnlineMart.Models;
using SAOnlineMart.Services;

namespace SAOnlineMart.Controllers
{
    public class AdminController : Controller
    {
        private readonly ProductService _productService;

        public AdminController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAdminModel model)
        {
            var product = new Product
            {
                Id = _productService.GetAllProducts().Count() + 1, // Simple ID generation
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

            // Add product to the service (this should be updated to persist to a database)
            _productService.GetAllProducts().Append(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductAdminModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductAdminModel model)
        {
            var product = _productService.GetProductById(model.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productService.GetProductById(id);
            if (product != null)
            {
                // Remove product from the service (this should be updated to persist to a database)
                var products = _productService.GetAllProducts().ToList();
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
