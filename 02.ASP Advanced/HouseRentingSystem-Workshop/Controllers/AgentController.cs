using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Agent;
using Microsoft.AspNetCore.Authorization;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormViewModel agent)
        {
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
