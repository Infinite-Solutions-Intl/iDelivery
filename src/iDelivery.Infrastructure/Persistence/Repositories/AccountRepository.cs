using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace iDelivery.Infrastructure.Persistence.Repositories;

public sealed class AccountRepository : Repository<Account, AccountId>, IAccountRepository
{
    public AccountRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public bool Exists(Email email)
    {
        var account = _dbContext.Accounts.FirstOrDefault(a => a.Email == email);
        return account is not null;
    }

    public async Task<bool> ExistsAsync(Email email, CancellationToken cancellationToken = default)
    {
        Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
        return account is not null;
    }

    public async Task<bool> AddUserAsync(Account account, User user, CancellationToken cancellationToken = default)
    {
        account.AddUser(user);
        int records = await _dbContext.SaveChangesAsync(cancellationToken);
        return records > 0;
    }

    public async Task<(bool success, Guid accountId)> IsValidKeyAsync(string key, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
        Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.ApiKey == key, cancellationToken);
        if(account is null)
            return (false, Guid.Empty);
        return (true, account.Id.Value);
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync(AccountId accountId, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .Where(u => u.AccountId == accountId)
            .ToArrayAsync(cancellationToken);
        return users;
    }

    public Task<User?> FindUserAsync(AccountId accountId, Email email, Password password)
    {
        return _dbContext.Users.FirstOrDefaultAsync(
            u =>
                u.AccountId == accountId &&
                u.Email == email &&
                u.Password == password);
    }
}
