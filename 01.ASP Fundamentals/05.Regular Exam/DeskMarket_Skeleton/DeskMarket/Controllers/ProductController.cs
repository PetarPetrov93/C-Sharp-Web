using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeskMarket.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();
            var model = await service.GetAllProductsAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductAddViewModel model = await service.GetCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.AddProductAsync(model, GetUserId());

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var model = await service.GetAllCartProductsAsync(GetUserId());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ProductEditViewModel model = await service.GetEditModelAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            if (model.SellerId != GetUserId())
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditViewModel model)
        {
            var product = await service.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            if (product.SellerId != GetUserId())
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await service.EditModelAsync(model, product);

            return RedirectToAction(nameof(Details), new { id = id});
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            Product product = await service.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            await service.AddToCartAsync(GetUserId(), product);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var product = await service.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            await service.RemoveFromCartAsync(GetUserId(), product);

            return RedirectToAction(nameof(Cart));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            ProductDetailsViewModel product = await service.GetProductDetailsAsync(id, GetUserId());

            if (product == null)
            {
                return BadRequest();
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await service.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            if (product.SellerId != GetUserId())
            {
                return Unauthorized();
            }

            string userName = User.Identity!.Name!;

            ProductDeleteViewModel model = new ProductDeleteViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Seller = userName,
                SellerId = product.SellerId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProductDeleteViewModel model)
        {
            var product = await service.GetProductByIdAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            await service.DeleteProductAsync(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
