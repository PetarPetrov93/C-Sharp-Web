using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> ForReview()
        {
            return View();
        }
    }
}
