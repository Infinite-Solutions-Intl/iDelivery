using iDelivery.Application.Repositories.Common;

namespace iDelivery.Application.Repositories;

public interface IAccountRepository : IRepository<Account, AccountId>
{
    bool Exists(Email email);
    Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = default);
    Task<bool> AddUserAsync(Account account, User user, CancellationToken? cancellationToken = default);
    Task<(bool success, Guid accountId)> IsValidKeyAsync(string key);
    Task<IReadOnlyList<User>> GetAllUsersAsync(AccountId accountId, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(AccountId accountId, Email email, Password password);
}
