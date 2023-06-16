using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories;

public sealed class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _dbContext;

    public AccountRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Account> AddAsync(Account entity, CancellationToken? cancellationToken = null)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public bool Exists(Email email)
    {
        var account = _dbContext.Accounts.FirstOrDefault(a => a.Email == email);
        return account is not null;
    }

    public async Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = null)
    {
        Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        return account is not null;
    }

    public Task<IReadOnlyList<Account>> GetAll(CancellationToken? cancellationToken = null)
    {
        IReadOnlyList<Account> accounts = _dbContext.Accounts.ToArray();
        return Task.FromResult(accounts);
    }

    public async Task<Account?> GetByIdAsync(AccountId id, CancellationToken? cancellationToken = null)
    {
        Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        return account;
    }

    public async Task<bool> AddUserAsync(Account account, User user, CancellationToken? cancellationToken = default)
    {
        account.AddUser(user);
        int records = await _dbContext.SaveChangesAsync();
        return records > 0;
    }
}
