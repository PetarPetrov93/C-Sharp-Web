using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Agent;
using HouseRentingSystem_Workshop.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }
        public async Task<IActionResult> Become()
        {
            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                return BadRequest();
            }

            var model = new BecomeAgentFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormViewModel agent)
        {
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
