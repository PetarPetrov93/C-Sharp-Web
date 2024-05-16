using HouseRentingSystem.Core.ViewModels.Statistics;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IStatisticService
    {
        Task<StatisticServiceModel> TotalAsync();
    }
}
