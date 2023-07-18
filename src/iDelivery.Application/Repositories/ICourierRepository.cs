using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;

public interface ICourierRepository : IRepository<Courier, UserId>
{
    Task<bool> UnAssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default);
    Task<bool> AssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Courier>> GetAllAsync(AccountId accountId, CancellationToken cancellationToken = default);
    Task<Courier?> GetByIdAsync(AccountId accountId, CourierId id, CancellationToken cancellationToken = default);
}