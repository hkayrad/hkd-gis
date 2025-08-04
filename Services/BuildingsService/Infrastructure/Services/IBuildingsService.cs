using System;
using BuildingsService.Domain;

namespace BuildingsService.Infrastructure.Services;

public interface IBuildingsService
{
    Task<Response<List<Building>>> GetBuildingsAsync(CancellationToken cancellationToken,
                                                     int? pageNumber,
                                                     int? pageSize,
                                                     string? sortBy,
                                                     bool? ascending);
}
