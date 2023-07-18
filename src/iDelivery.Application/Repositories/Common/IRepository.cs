using iDelivery.Domain.Common.Models;

namespace iDelivery.Application.Repositories.Common;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}
