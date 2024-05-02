using Microsoft.AspNetCore.Mvc;

namespace Create_Simple_Pages.Controllers
{
    public class NumbersController : Controller
    {
        private readonly ILogger<NumbersController> _logger;

        public NumbersController(ILogger<NumbersController> logger)
        {
            _logger = logger;
        }
        public IActionResult NumsToFifty()
        {
            return View();
        }

        public IActionResult NumsToN(int count = 3)
        {
            ViewBag.Count = count;
            return View();
        }
    }
}
