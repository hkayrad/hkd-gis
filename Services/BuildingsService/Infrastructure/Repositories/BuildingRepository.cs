using System;
using System.ComponentModel.DataAnnotations;

namespace BuildingsService.Infrastructure.Repositories;

public class BuildingRepository : IBuildingRepository
{
    [MaxLength(12)]
    public string? OsmId { get; set; }
    [MaxLength(4)]
    public int Code { get; set; }
    [MaxLength(28)]
    public string? FClass { get; set; }
    [MaxLength(100)]
    public string? Name { get; set; }
    [MaxLength(20)]
    public string? Type { get; set; }
}
