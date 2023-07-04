using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.CommandAggregate.ValueObjects;
using iDelivery.Domain.CourierAggregate;

namespace iDelivery.Application.Repositories;

public interface ICourierRepository : IRepository<Courier, UserId>
{
    Task<bool> UnAssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default);
    Task<bool> AssignAsync(Courier courier, CommandId commandId, CancellationToken cancellationToken = default);
}