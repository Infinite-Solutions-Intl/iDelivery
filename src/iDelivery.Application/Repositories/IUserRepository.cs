using iDelivery.Application.Repositories.Common;

namespace iDelivery.Application.Repositories;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> FindUserAsync(Email email, Password password);
}
