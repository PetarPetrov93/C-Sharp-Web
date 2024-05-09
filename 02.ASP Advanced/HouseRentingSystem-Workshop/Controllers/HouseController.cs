using HouseRentingSystem.Core.ViewModels.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
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

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormViewModel model)
        {
            return RedirectToAction(nameof(Details), new {id = "1"});
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
