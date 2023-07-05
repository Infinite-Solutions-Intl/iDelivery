using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Infrastructure.Persistence.Repositories.Base;

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

    public async Task<bool> UnAssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default)
    {
        courier.RemoveCommand(commandId);
        int records = await _dbContext.SaveChangesAsync(cancellationToken);
        return records > 0;
    }
}
