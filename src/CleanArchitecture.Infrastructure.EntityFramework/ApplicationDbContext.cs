using CleanArchitecture.Application.Common.Abstractions.Data;
using CleanArchitecture.Domain.Assets;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.EntityFramework;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<Asset> Assets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}