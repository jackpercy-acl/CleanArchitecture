using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Abstractions.Data.Repositories;

public interface IRepository<T>
    where T : class, IEntity
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Delete(T entity);

    IQueryable<T> GetAll();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}