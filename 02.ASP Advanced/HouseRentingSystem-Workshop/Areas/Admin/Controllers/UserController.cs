using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Administrator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static HouseRentingSystem.Core.Constants.AdminConstants;

namespace HouseRentingSystem_Workshop.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;
        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }
        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserServiceModel>>(UserCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await userService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                memoryCache.Set(UserCacheKey, model, cacheOptions);
            }


            return View(model);
        }
    }
}
