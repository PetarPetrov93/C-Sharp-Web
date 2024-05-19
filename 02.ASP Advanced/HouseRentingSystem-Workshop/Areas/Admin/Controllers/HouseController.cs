using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HouseRentingSystem_Workshop.Areas.Admin.Controllers
{
    public class HouseController : AdminBaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        public HouseController(IHouseService _houseService, IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;
        }
        public async Task<IActionResult> Mine()
        {
            var currentUserId = User.Id();
            var agentId = await agentService.GetAgentIdAsync(currentUserId) ?? 0;

            var myHouses = new MyHousesViewModel()
            {
                AddedHouses = await houseService.AllHousesByAgentIdAsync(agentId),
                RentedHouses = await houseService.AllHousesByUserIdAsync(currentUserId),
            };
            return View(myHouses);
        }
    }
}
