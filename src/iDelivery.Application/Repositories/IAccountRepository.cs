using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.AccountAggregate;
using iDelivery.Domain.AccountAggregate.ValueObjects;

namespace iDelivery.Application.Repositories;

public interface IAccountRepository : IRepository<Account, AccountId>
{
    bool Exists(Email email);
    Task<bool> ExistsAsync(Email email, CancellationToken? cancellationToken = default);
}
