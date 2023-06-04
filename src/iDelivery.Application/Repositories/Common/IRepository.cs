using iDelivery.Domain.Common.Models;

namespace iDelivery.Application.Repositories.Common;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    Task<IReadOnlyList<TEntity>> GetAll(CancellationToken? cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken? cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken? cancellationToken = default);
}
