using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.CourierAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;
public interface ICourierRepository : IRepository<Courier, CourierId>
{
    Task<Courier> UpdateCourierAsync(Courier courier, CancellationToken cancellationToken = default);
} 