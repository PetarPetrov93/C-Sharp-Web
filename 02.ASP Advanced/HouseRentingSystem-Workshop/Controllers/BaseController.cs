using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
