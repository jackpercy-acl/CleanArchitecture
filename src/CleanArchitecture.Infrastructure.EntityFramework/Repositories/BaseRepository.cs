using CleanArchitecture.Application.Common.Abstractions.Data.Repositories;
using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.EntityFramework.Repositories;

internal abstract class BaseRepository<T>(ApplicationDbContext context) : IRepository<T>
    where T : class, IEntity
{
    public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return GetAll().Where(x => x.Id == id).SingleOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        context.Update(entity);
    }

    public void Delete(T entity)
    {
        context.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return context.Set<T>();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}