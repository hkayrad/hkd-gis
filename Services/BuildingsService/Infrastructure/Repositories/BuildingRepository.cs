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
        var queryable = _buildings.AsQueryable();

        if (ascending)
        {
            queryable = queryable.OrderBy(e => EF.Property<object>(e, sortBy));
        }
        else
        {
            queryable = queryable.OrderByDescending(e => EF.Property<object>(e, sortBy));
        }

        Console.WriteLine($"Fetching buildings: Page {pageNumber}, Size {pageSize}, Sort By {sortBy}, Ascending {ascending}");

        return await queryable
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}
