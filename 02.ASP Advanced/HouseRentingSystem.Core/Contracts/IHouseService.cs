using HouseRentingSystem.Core.ViewModels.Home;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseServiceIndexViewModel>> LastThreeHouses();
    }
}
