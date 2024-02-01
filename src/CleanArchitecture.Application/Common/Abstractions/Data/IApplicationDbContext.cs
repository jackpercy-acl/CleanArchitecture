using CleanArchitecture.Domain.Assets;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Abstractions.Data;

public interface IApplicationDbContext
{
    public DbSet<Asset> Assets { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}