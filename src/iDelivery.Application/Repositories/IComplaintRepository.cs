using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Application.Repositories;
public interface IComplaintRepository : IRepository<Complaint, ComplaintId>
{
    Task<IReadOnlyList<Complaint>> GetAllAsync(AccountId accountId, CancellationToken cancellationToken = default);
    Task<Complaint?> GetByIdAsync(AccountId accountId, ComplaintId id, CancellationToken cancellationToken = default);
}
