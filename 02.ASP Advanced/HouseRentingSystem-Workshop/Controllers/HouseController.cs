using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.House;
using HouseRentingSystem_Workshop.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace HouseRentingSystem_Workshop.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HouseController(IHouseService _houseService, IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;

        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = new AllHousesQueryViewModel();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = new AllHousesQueryViewModel();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new HouseDetailsViewModel();
            return View(model);
        }

        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
            var model = new HouseFormViewModel()
            {
                Categories = await houseService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HouseFormViewModel model)
        {
            if (!await houseService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new {id = newHouseId});
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = new HouseFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormViewModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = new HouseFormViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HouseDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
