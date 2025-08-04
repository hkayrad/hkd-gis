using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NetTopologySuite.Geometries;
using HKS.GIS.SharedKernel.Extensions;

namespace BuildingsService.Domain;

public class Building
{
    [Required]
    [Key]
    public int Id { get; set; }
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
    [JsonIgnore]
    public Geometry? Geometry { get; set; }

    [JsonPropertyName("wkt")]
    public string? Wkt => Geometry?.ToWkt();
}
