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

    public Task<User?> FindUserAsync(Email email, Password password)
    {
        User? user = null;
        try
        {
            user = _users.Find(u => u.Email == email && u.Password == password);
        }
        catch (Exception)
        {
            user = null;
            throw;
        }
        return Task.FromResult(user);
    }

    public Task<IReadOnlyList<User>> GetAll(CancellationToken? cancellationToken = null)
    {
        IReadOnlyList<User> users = _users.AsReadOnly();
        return Task.FromResult(users);
    }

    public Task<User?> GetByIdAsync(UserId id, CancellationToken? cancellationToken = null)
    {
        User? user = null;
        try
        {
            user = _users.Find(u => u.Id == id);
        }
        catch (Exception)
        {
            user = null;
            throw;
        }
        return Task.FromResult(user);
    }
}
