using BuildingsService.Infrastructure;
using BuildingsService.Infrastructure.Data;
using BuildingsService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Buildings Service API", Version = "v1" });
});

string? postgresqlConnectionString = Environment.GetEnvironmentVariable("BUILDINGS_POSTGRESQL_CONNECTION_STRING");

if (string.IsNullOrEmpty(postgresqlConnectionString))
    throw new InvalidOperationException("BUILDINGS_POSTGRESQL_CONNECTION_STRING environment variable is not set.");

builder.Services.AddDbContext<BuildingsContext>(options =>
    options.UseNpgsql(
        postgresqlConnectionString,
        opts => opts.UseNetTopologySuite()
    )
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBuildingsService, PostgresqlBuildingsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
