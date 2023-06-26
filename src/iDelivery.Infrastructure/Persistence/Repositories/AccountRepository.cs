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

    public async Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = null)
    {
        Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        return account is not null;
    }

    public async Task<bool> AddUserAsync(Account account, User user, CancellationToken? cancellationToken = default)
    {
        account.AddUser(user);
        int records = await _dbContext.SaveChangesAsync();
        return records > 0;
    }
}
