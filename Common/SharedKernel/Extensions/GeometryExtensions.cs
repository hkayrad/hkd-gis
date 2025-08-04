using System;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace HKD.GIS.SharedKernel.Extensions;

public static class GeometryExtensions
{
    private static readonly WKTReader _reader = new();
    private static readonly WKTWriter _writer = new();

    public static Geometry ToGeometry(this string wkt)
    {
        if (string.IsNullOrWhiteSpace(wkt))
            throw new ArgumentException("WKT cannot be null or empty.", nameof(wkt));

        return _reader.Read(wkt);
    }

    public static string ToWkt(this Geometry geometry)
    {
        if (geometry == null)
            throw new ArgumentNullException(nameof(geometry));

        return _writer.Write(geometry);
    }
}
