using iDelivery.Api.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;
public class CouriersController : ApiBaseController
{
    private readonly ISender _sender;

    public CouriersController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> PostCourier(AddCourierRequest request)
    {
        AddCourier courier = new (
            request.CommandId
        );
        var response = await _sender.Send(courier);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok(response.Value);
    }

}