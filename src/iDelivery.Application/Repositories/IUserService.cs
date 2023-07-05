namespace iDelivery.Application.Repositories;

public interface IUserService
{
    Task<bool> ExistsAsync(AccountId accountId, Email email, CancellationToken cancellationToken = default);
}
