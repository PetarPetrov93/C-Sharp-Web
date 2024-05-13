namespace HouseRentingSystem.Core.ViewModels.House
{
    public class HouseQueryServiceModel
    {
        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseServiceModel> Houses { get; set; } = new HashSet<HouseServiceModel>();
    }
}
