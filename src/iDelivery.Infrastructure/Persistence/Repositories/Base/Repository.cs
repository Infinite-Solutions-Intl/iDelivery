using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories.Base;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    protected readonly AppDbContext _dbContext;

    protected Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _dbContext
            .Set<TEntity>()
            .ToArrayAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
        return entity;
    }
}
