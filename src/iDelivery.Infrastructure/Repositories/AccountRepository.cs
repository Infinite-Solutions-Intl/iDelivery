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
        Account? account = null;
        try
        {
            account = _accounts.Find(a => a.Email == email);
        }
        catch (Exception)
        {
            account = null;
        }
        return account is not null;
    }

    public Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = null)
    {
        Account? account = null;
        try
        {
            account = _accounts.Find(a => a.Email == email);
        }
        catch (Exception)
        {
            account = null;
            throw;
        }
        return Task.FromResult(account is not null);
    }

    public Task<IReadOnlyList<Account>> GetAll(CancellationToken? cancellationToken = null)
    {
        IReadOnlyList<Account> accounts = _accounts.AsReadOnly();
        return Task.FromResult(accounts);
    }

    public Task<Account?> GetByIdAsync(AccountId id, CancellationToken? cancellationToken = null)
    {
        Account? account = null;
        try
        {
            account = _accounts.Find(a => a.Id == id);
        }
        catch (Exception)
        {
            account = null;
            throw;
        }
        return Task.FromResult(account);
    }
}
