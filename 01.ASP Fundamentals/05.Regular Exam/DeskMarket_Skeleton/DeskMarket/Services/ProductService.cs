using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DeskMarket.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddProductAsync(ProductAddViewModel model, string userId)
        {
            string dateTimeString = $"{model.AddedOn}";

            if (!DateTime.TryParseExact(dateTimeString, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var newProduct = new Product
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                AddedOn = parseDateTime,
                CategoryId = model.CategoryId,
                SellerId = userId
            };

            await context.AddAsync(newProduct);
            await context.SaveChangesAsync();
        }

        public async Task AddToCartAsync(string userId, Product product)
        {
            bool isAlreadyAdded = await context.ProductsClients
                .AnyAsync(pc => pc.ClientId == userId && pc.ProductId == product.Id);

            if (isAlreadyAdded) 
            {
                return;
            }

            var productClient = new ProductClient
            {
                ProductId = product.Id,
                ClientId = userId
            };

            await context.ProductsClients.AddAsync(productClient);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            product.IsDeleted = true;

            await context.SaveChangesAsync();
        }

        public async Task EditModelAsync(ProductEditViewModel model, Product product)
        {
            string dateTimeString = $"{model.AddedOn}";

            if (!DateTime.TryParseExact(dateTimeString, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDateTime))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            product.ProductName = model.ProductName;
            product.Description = model.Description;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.AddedOn = parseDateTime;
            product.SellerId = model.SellerId;
            product.CategoryId = model.CategoryId;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCartViewModel>> GetAllCartProductsAsync(string userId)
        {
            return await context.ProductsClients
                .Where(pc => pc.ClientId == userId && pc.Product.IsDeleted == false)
                .Select(pc => new ProductCartViewModel
                {
                    Id = pc.ProductId,
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price,
                    ImageUrl = pc.Product.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(string userId)
        {
            return await context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductIndexViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    IsSeller = userId != null && p.SellerId == userId,
                    HasBought = context.ProductsClients.Any(pc => pc.ProductId == p.Id && pc.ClientId == userId)
                })
                .ToListAsync();
        }

        public async Task<ProductAddViewModel> GetCategoriesAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel 
                { 
                    Id = c.Id, Name = c.Name 
                })
                .ToListAsync();

            var model = new ProductAddViewModel
            {
                Categories = categories
            };

            return model;
        }

        public async Task<ProductEditViewModel> GetEditModelAsync(int id)
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return await context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductEditViewModel
                {
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn.ToString("dd-MM-yyyy"),
                    SellerId = p.SellerId,
                    CategoryId = p.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int id, string userId)
        {
            return await context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    AddedOn= p.AddedOn.ToString("dd-MM-yyyy"),
                    CategoryName = p.Category.Name,
                    Seller = p.Seller.UserName,
                    HasBought = context.ProductsClients.Any(pc => pc.ProductId == p.Id && pc.ClientId == userId)
                })
                .FirstOrDefaultAsync();
        }

        public async Task RemoveFromCartAsync(string userId, Product product)
        {
            var productClient = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ClientId == userId && pc.ProductId == product.Id);

            if (productClient != null) 
            {
                context.ProductsClients.Remove(productClient);
                await context.SaveChangesAsync();
            }
        }
    }
}
