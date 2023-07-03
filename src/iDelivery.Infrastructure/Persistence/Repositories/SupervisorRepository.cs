using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.SupervisorAggregate;
using iDelivery.Infrastructure.Persistence.Repositories.Base;

namespace iDelivery.Infrastructure.Persistence.Repositories;

public class SupervisorRepository : Repository<Supervisor, UserId>, ISupervisorRepository
{
    public SupervisorRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
