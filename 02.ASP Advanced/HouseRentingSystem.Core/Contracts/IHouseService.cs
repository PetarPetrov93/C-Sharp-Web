using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.ViewModels.Home;
using HouseRentingSystem.Core.ViewModels.House;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseServiceIndexViewModel>> LastThreeHousesAsync();
        Task<IEnumerable<HouseCategoryServiceViewModel>> AllCategoriesAsync();
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<int> CreateAsync(HouseFormViewModel model, int agentId);
        Task<HouseQueryServiceModel> AllAsync(string? category = null,
                                              string? searchTerm = null,
                                              HouseSorting sorting = HouseSorting.Newest,
                                              int currentPage = 1,
                                              int housePerPage = 2);
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId);
        Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId);
        Task<bool> ExistAsync(int id);
        Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id);
    }
}
