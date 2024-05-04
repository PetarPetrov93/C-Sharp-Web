using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProductsSimpleApp.Models;
using System.Text;
using System.Text.Json;

namespace ProductsSimpleApp.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>() 
            { 
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Chese",
                    Price = 7.00
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50
                }
            };

        [ActionName("My-Products")]
        public IActionResult AllProducts(string keyWord = "")
        {
            var filteredProducts = products.Where(p => p.Name.ToLower().Contains(keyWord.ToLower()));
            if (!filteredProducts.Any())
            {
                return View(products);
            }
            return View(filteredProducts);
        }

        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return View("My-Products", products);
            }

            return View(product);
        }

        public IActionResult AllAsJSON()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

            return Content(sb.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
        }
    }
}
