using iDelivery.Application.Repositories;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.Entities;
using iDelivery.Domain.AccountAggregate.ValueObjects;
using iDelivery.Domain.Common.Utilities;
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

    public Task<User?> FindUserByEmailAsync(AccountId accountId, Email email, Password password, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users.FirstOrDefaultAsync(
            u =>
                u.AccountId == accountId &&
                u.Email == email &&
                u.Password == password,
                cancellationToken);
    }

    public async Task<User?> ChangeRoleAsync(AccountId accountId, UserId userId, string previousRole, string newRole, Guid? supervisorId, string? poBox, CancellationToken cancellationToken = default)
    {
        Account? account = await GetByIdAsync(accountId, cancellationToken);
        User? user = await _dbContext.Users.FirstOrDefaultAsync(
            u =>
                u.AccountId == accountId &&
                u.Id == userId,
            cancellationToken);

        if (user is null || account is null)
            return null;

        if (user.Role != previousRole)
            return null;

        User newUser = newRole switch
        {
            Roles.Partner => user.ToPartner(poBox!),
            Roles.Manager => user.ToManager(),
            Roles.Supervisor => user.ToSupervisor(),
            Roles.Courier => user.ToCourier((Guid)supervisorId!),
            _ => user
        };

        // _dbContext.Users.Update(user);
        _dbContext.Users.Remove(user);
        account.RemoveUser(user);
        account.AddUser(newUser);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return newUser;
    }

    public Task<bool> ExistsUserAsync(AccountId accountId, Email email, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users.AnyAsync(u => u.Email == email && u.AccountId == accountId, cancellationToken);
    }

    public Task<User?> FindUserAsync(AccountId accountId, UserId userId, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId && u.AccountId == accountId, cancellationToken);
    }

    public Task<int> DeleteUserAsync(Account account, User user, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .Where(
                u => 
                    u.Id == user.Id &&
                    u.AccountId == account.Id)
            .ExecuteDeleteAsync(cancellationToken);
    }
}
