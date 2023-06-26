using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories;

public sealed class UserRepository : Repository<User, UserId>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public Task<User?> FindUserAsync(Email email, Password password)
    {
        return _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
