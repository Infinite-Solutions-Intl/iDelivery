using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.SupervisorAggregate;

namespace iDelivery.Application.Repositories;

public interface ISupervisorRepository : IRepository<Supervisor, UserId>
{
}
