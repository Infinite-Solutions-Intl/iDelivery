namespace iDelivery.Application.Complaints.Add;

public sealed class AddComplaintHandler : IRequestHandler<AddComplaint, Result<ComplaintResponse>>
{
    private readonly IComplaintRepository _complaintRepository;

    public AddComplaintHandler(IComplaintRepository complaintRepository)
    {
        _complaintRepository = complaintRepository;
    }
    public async Task<Result<ComplaintResponse>> Handle(AddComplaint request, CancellationToken cancellationToken)
    {
       Complaint complaint = Complaint.Create(
        request.Objet,
        request.Message,
        //request.CommandId,
        //request.ManagerId,
        request.PictureBlob
       );
       try
       {
        await _complaintRepository.AddAsync(complaint, cancellationToken);
        return new ComplaintResponse(
            complaint.Id.Value,
            complaint.Objet,
            complaint.Message,
            complaint.PictureBlob
        );
       }
       catch (Exception)
       {
        return Result.Fail(new AddCommandError());
       }
    }
}
