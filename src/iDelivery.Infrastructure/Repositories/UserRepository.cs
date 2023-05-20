using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();
    public Task<User> AddAsync(User entity, CancellationToken? cancellationToken = null)
    {
        _users.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<User> FindUserAsync(Email email, Password password)
    {
        var user = _users.First(u => u.Email == email && u.Password == password);
        return Task.FromResult(user);
    }

    public Task<IReadOnlyList<User>> GetAll(CancellationToken? cancellationToken = null)
    {
        IReadOnlyList<User> users = _users.AsReadOnly();
        return Task.FromResult(users);
    }

    public Task<User> GetByIdAsync(UserId id, CancellationToken? cancellationToken = null)
    {
        var user = _users.First(u => u.Id == id);
        return Task.FromResult(user);
    }
}
