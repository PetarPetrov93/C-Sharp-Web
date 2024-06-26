﻿using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HouseRentingSystem_Workshop.Controllers;

namespace HouseRentingSystem_Workshop.Attributes
{
    public class MustBeAgentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAgentService? agentService = context.HttpContext.RequestServices.GetService<IAgentService>();

            if (agentService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (agentService != null && !agentService.ExistsByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new RedirectToActionResult(nameof(AgentController.Become), "Agent", null);
            }
        }
    }
}
