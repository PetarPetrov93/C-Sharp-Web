using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HouseRentingSystem_Workshop.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService _houseService)
        {
            houseService = _houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await houseService.LastThreeHousesAsync();
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
