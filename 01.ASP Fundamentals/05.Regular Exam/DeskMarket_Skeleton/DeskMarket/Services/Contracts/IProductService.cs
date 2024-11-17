using DeskMarket.Data.Models;
using DeskMarket.Models;

namespace DeskMarket.Services.Contracts
{
    public interface IProductService
    {
        Task<ProductAddViewModel> GetCategoriesAsync();

        Task AddProductAsync(ProductAddViewModel model, string userId);

        Task<IEnumerable<ProductIndexViewModel>> GetAllProductsAsync(string userId);

        Task<IEnumerable<ProductCartViewModel>> GetAllCartProductsAsync(string userId);

        Task<ProductEditViewModel> GetEditModelAsync(int id);

        Task EditModelAsync(ProductEditViewModel model, Product product);

        Task<Product> GetProductByIdAsync(int id);

        Task AddToCartAsync(string userId, Product product);

        Task RemoveFromCartAsync(string userId, Product product);

        Task<ProductDetailsViewModel> GetProductDetailsAsync(int id, string userId);

        Task DeleteProductAsync(Product product);
    }
}
