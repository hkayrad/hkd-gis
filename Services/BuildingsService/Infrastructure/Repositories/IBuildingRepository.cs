using System;
using BuildingsService.Domain;

namespace BuildingsService.Infrastructure.Repositories;

public interface IBuildingRepository
{
    Task<List<Building>> GetBuildingsAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 1000, string sortBy = "Id", bool ascending = true);
}
