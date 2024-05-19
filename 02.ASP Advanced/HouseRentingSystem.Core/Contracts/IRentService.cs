using HouseRentingSystem.Core.ViewModels.Administrator;

namespace HouseRentingSystem.Core.Contracts
{
    public interface IRentService
    {
        Task<IEnumerable<RentServiceModel>> AllAsync();
    }
}
