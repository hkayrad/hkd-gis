using BuildingsService.Domain;
using BuildingsService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildingsService.Infrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    private readonly BuildingsContext _context;
    private readonly DbSet<Building> _buildings;

    public BuildingRepository(BuildingsContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _buildings = _context.Set<Building>();
    }

    public async Task<List<Building>> GetBuildingsAsync(CancellationToken cancellationToken,
                                                        int pageNumber,
                                                        int pageSize,
                                                        string sortBy,
                                                        bool ascending)
    {
        var buildings = await _context.Buildings
            .FromSql($"SELECT *, ST_AsGeoJSON(geometry) as geojson FROM buildings")
            .OrderBy(x => EF.Property<object>(x, sortBy))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return buildings;

    }
}