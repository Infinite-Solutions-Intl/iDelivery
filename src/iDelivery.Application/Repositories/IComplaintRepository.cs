using iDelivery.Application.Repositories.Common;
using iDelivery.Domain.Common.ValueObjects;

namespace iDelivery.Application.Repositories;
public interface IComplaintRepository : IRepository<Complaint, ComplaintId>
{
    
}