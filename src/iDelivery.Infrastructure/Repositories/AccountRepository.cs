using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Infrastructure.Repositories;

public sealed class AccountRepository : IAccountRepository
{
    private readonly List<Account> _accounts = new();
    public Task<Account> AddAsync(Account entity, CancellationToken? cancellationToken = null)
    {
        _accounts.Add(entity);
        return Task.FromResult(entity);
    }

    public bool Exists(Email email)
    {
        var account = _accounts.FirstOrDefault(a => a.Email == email);
        return account is not null;
    }

    public Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = null)
    {
        var exists = _accounts.FirstOrDefault(a => a.Email == email) is not null;
        return Task.FromResult(exists);
    }

    public Task<IReadOnlyList<Account>> GetAll(CancellationToken? cancellationToken = null)
    {
        IReadOnlyList<Account> accounts = _accounts.AsReadOnly();
        return Task.FromResult(accounts);
    }

    public Task<Account> GetByIdAsync(AccountId id, CancellationToken? cancellationToken = null)
    {
        var account = _accounts.First(a => a.Id == id);
        return Task.FromResult(account);
    }
}
