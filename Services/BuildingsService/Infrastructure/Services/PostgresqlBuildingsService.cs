using System;
using BuildingsService.Domain;
using HKD.GIS.SharedKernel.Domain;

namespace BuildingsService.Infrastructure.Services;

public class PostgresqlBuildingsService(IUnitOfWork unitOfWork) : IBuildingsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Response<List<Building>>> GetBuildingsAsync(CancellationToken cancellationToken,
                                                                int? pageNumber,
                                                                int? pageSize,
                                                                string? sortBy,
                                                                bool? ascending)
    {
        var buildings = await _unitOfWork.BuildingsRepository.GetBuildingsAsync(cancellationToken, pageNumber ?? 1, pageSize ?? 1000, sortBy ?? "Id", ascending ?? true);

        if (buildings == null || buildings.Count == 0)
            return Response<List<Building>>.Failure("No buildings found.");

        return Response<List<Building>>.Success(buildings, "Buildings retrieved successfully.");
    }
}