using iDelivery.Application.Repositories.Common;

namespace iDelivery.Application.Repositories;

public interface IAccountRepository : IRepository<Account, AccountId>
{
    Task<(bool success, Guid accountId)> IsValidKeyAsync(string key, CancellationToken cancellationToken = default);
    bool Exists(Email email);
    Task<bool> ExistsAsync(Email email, CancellationToken cancellationToken = default);
    Task<bool> ExistsUserAsync(AccountId accountId, Email email, CancellationToken cancellationToken = default);
    Task<bool> ExistsUserAsync(AccountId accountId, UserId userId, CancellationToken cancellationToken = default);
    Task<bool> AddUserAsync(Account account, User user, CancellationToken cancellationToken = default);
    Task<User?> FindUserAsync(AccountId accountId, UserId userId, CancellationToken cancellationToken = default);
    Task<User?> FindUserByEmailAsync(AccountId accountId, Email email, Password password, CancellationToken cancellationToken = default);
    Task<User?> ChangeRoleAsync(AccountId accountId, UserId userId, string previousRole, string newRole, Guid? supervisorId, string? poBox, CancellationToken cancellationToken = default);
    Task<int> DeleteUserAsync(Account account, User user, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<User>> GetAllUsersAsync(AccountId accountId, CancellationToken cancellationToken = default);
}
