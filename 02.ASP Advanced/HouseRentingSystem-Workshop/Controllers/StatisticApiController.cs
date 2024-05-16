using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem_Workshop.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statisticService;
        public StatisticApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();
            return Ok(result);
        }
    }
}
