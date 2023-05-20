using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User> FindUserAsync(Email email, Password password);
}
