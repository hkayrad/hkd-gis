using BuildingsService.Domain;
using BuildingsService.Infrastructure.Services;
using HKD.GIS.SharedKernel.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BuildingsService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuildingsController(IBuildingsService buildingsService) : ControllerBase
    {
        private readonly IBuildingsService _buildingsService = buildingsService;

        [HttpGet]
        public async Task<Response<List<Building>>> GetBuildings([FromQuery(Name = "pageNumber")] int? pageNumber,
                                                                [FromQuery(Name = "pageSize")] int? pageSize,
                                                                [FromQuery(Name = "sortBy")] string? sortBy,
                                                                [FromQuery(Name = "ascending")] bool? ascending)
        {
            return await _buildingsService.GetBuildingsAsync(CancellationToken.None, pageNumber, pageSize, sortBy, ascending);
        }
    }
}
