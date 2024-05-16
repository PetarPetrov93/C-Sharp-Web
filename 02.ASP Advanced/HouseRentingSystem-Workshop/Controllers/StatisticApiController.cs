using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statistics;
        public StatisticApiController(IStatisticService _statistics)
        {
            statistics = _statistics;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statistics.TotalAsync();
            return Ok(result);
        }
    }
}
