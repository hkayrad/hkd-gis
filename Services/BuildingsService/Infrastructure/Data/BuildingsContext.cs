using System;
using BuildingsService.Domain;
using Microsoft.EntityFrameworkCore;

namespace BuildingsService.Infrastructure.Data;

public class BuildingsContext(DbContextOptions<BuildingsContext> options) : DbContext(options)
{
    public DbSet<Building> Buildings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.OsmId).HasName("buildings_pk");

            entity.ToTable("buildings");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.OsmId)
                .HasMaxLength(12)
                .HasColumnName("osm_id");
            entity.Property(e => e.Code)
                .HasMaxLength(4)
                .HasColumnName("code");
            entity.Property(e => e.FClass)
                .HasMaxLength(28)
                .HasColumnName("fclass");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasColumnName("type");
            entity.Property(e => e.Geometry)
                .IsRequired()
                .HasColumnType("geometry")
                .HasColumnName("geometry");
        });

    }
}
