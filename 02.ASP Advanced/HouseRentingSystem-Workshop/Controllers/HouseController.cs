﻿using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Extensions;
using HouseRentingSystem.Core.ViewModels.House;
using HouseRentingSystem_Workshop.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static HouseRentingSystem.Core.Constants.MessageConstants;

namespace HouseRentingSystem_Workshop.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly ILogger logger;

        public HouseController(IHouseService _houseService, IAgentService _agentService, ILogger<HouseController> _logger)
        {
            houseService = _houseService;
            agentService = _agentService;
            logger = _logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryViewModel model)
        {
            var houses = await houseService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.HousesPerPage);

            model.TotalHousesCount = houses.TotalHousesCount;
            model.Houses = houses.Houses;
            model.Categories = await houseService.AllCategoriesNamesAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            IEnumerable<HouseServiceModel> model;

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "House", new {area = "Admin"});
            }

            if (await agentService.ExistsByIdAsync(userId))
            {
                var agentId = await agentService.GetAgentIdAsync(userId) ?? 0;
                model = await houseService.AllHousesByAgentIdAsync(agentId);
            }
            else
            {
                model = await houseService.AllHousesByUserIdAsync(userId);
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            var model = await houseService.HouseDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

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
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();

                return View(model);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);

            return RedirectToAction(nameof(Details), new {id = newHouseId, information = model.GetInformation()});
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await houseService.GetHouseFormViewModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HouseFormViewModel model)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithIdAsync(id, User.Id()) == false
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (!await houseService.CategoryExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await houseService.AllCategoriesAsync();
                return View(model);
            }

            await houseService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = id, information = model.GetInformation()});
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithIdAsync(id, User.Id())
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var house = await houseService.HouseDetailsByIdAsync(id);
            var model = new HouseDetailsViewModel()
            {
                Id = house.Id,
                Address = house.Address,
                ImageUrl = house.ImageUrl,
                Title = house.Title,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel model)
        {
            if (!await houseService.ExistAsync(model.Id))
            {
                return BadRequest();
            }

            if (!await houseService.HasAgentWithIdAsync(model.Id, User.Id())
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await houseService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RentAsync(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            if (await agentService.ExistsByIdAsync(User.Id())
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            if (await houseService.IsRentedAsync(id))
            {
                return BadRequest();
            }

            await houseService.RentAsync(id, User.Id());

            TempData[UserMessageSuccess] = "You have rented the house!";

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (!await houseService.ExistAsync(id))
            {
                return BadRequest();
            }

            try
            {
                await houseService.LeaveAsync(id, User.Id());
                TempData[UserMessageError] = "You have left the house!";
            }
            catch (UnauthorizedActionException ex)
            {
                logger.LogError(ex, "HouseController/Leave");
                return Unauthorized();
            }

            return RedirectToAction(nameof(All));
        }
    }
}
