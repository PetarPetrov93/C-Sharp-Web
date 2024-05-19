using HouseRentingSystem.Core.ViewModels.House;

namespace HouseRentingSystem.Core.ViewModels.Administrator
{
    public class MyHousesViewModel
    {
        public IEnumerable<HouseServiceModel> AddedHouses { get; set; } = new List<HouseServiceModel>();
        public IEnumerable<HouseServiceModel> RentedHouses { get; set; } = new List<HouseServiceModel>();
    }
}
