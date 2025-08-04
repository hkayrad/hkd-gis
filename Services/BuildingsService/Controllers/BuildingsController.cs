using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBuildings()
        {
            // Simulate fetching buildings data
            var buildings = new List<string> { "Building A", "Building B", "Building C" };
            return await Task.FromResult(Ok(buildings));
        }
    }
}
