using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.PlanAggregate;
using iDelivery.Domain.PlanAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;
public interface IPlanRepository : IRepository<Plan, PlanId>
{
    Task<Plan> UpdatePlanAsync(Plan plan, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Plan>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Plan?> GetByIdAsync(PlanId id, CancellationToken cancellationToken = default);
}
