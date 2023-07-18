using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;
using iDelivery.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories;
public sealed class CourierRepository : Repository<Courier, UserId>, ICourierRepository
{
    public CourierRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> AssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default)
    {
        courier.AddCommand(commandId);
        int records = await _dbContext.SaveChangesAsync(cancellationToken);
        return records > 0;
    }

    public async Task<IReadOnlyList<Courier>> GetAllAsync(AccountId accountId, CancellationToken cancellationToken = default)
    {
        var couriers = await _dbContext.Couriers
            .Where(c => c.AccountId == accountId)
            .ToArrayAsync(cancellationToken);

        return couriers;
    }

    public Task<Courier?> GetByIdAsync(AccountId accountId, CourierId id, CancellationToken cancellationToken = default)
    {
        return _dbContext
            .Couriers
            .FirstOrDefaultAsync(c => 
                c.Id == id &&
                c.AccountId == accountId, cancellationToken);
    }

    public async Task<bool> UnAssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default)
    {
        courier.RemoveCommand(commandId);
        int records = await _dbContext.SaveChangesAsync(cancellationToken);
        return records > 0;
    }
}
