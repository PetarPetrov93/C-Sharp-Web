using HouseRentingSystem.Core.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        public async Task<IActionResult> Become()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormViewModel agent)
        {
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
