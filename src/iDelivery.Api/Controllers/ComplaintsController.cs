using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Complaints;
using iDelivery.Contracts.Complaints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

public class ComplaintsController : ApiBaseController
{
    private readonly ISender _sender;
    public ComplaintsController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> PostComplaint(AddComplaintRequest request)
    {
        AddComplaint complaint = new(
            request.Objet,
            request.Message,
            request.PictureBlob
        );
        var response = await _sender.Send(complaint);
        if(response.IsFailed)
        return BadRequest(response.Errors[0].Message);
        return Ok(response.Value);
    }
}