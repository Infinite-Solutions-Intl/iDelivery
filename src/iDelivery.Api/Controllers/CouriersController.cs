using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Couriers.Add;
using iDelivery.Application.Couriers.Delete;
using iDelivery.Contracts.Couriers;
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
    [HttpPost("{courierId}/command/{commandId}")]
    public async Task<IActionResult> PostCourierAsync(Guid courierId, Guid commandId)
    {
        AssignCommand courier = new (courierId, commandId);
        var response = await _sender.Send(courier);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok();
    }
    [HttpDelete("{courierId}/delivery/{deliveryId}")]
    public IActionResult DeleteDeliveryAsync()
    {
        /*DeleteCourier courier = new(courierId, deliveryId);
        var response = await _sender.Send(courier);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);
        return Ok();*/
        return Ok();
    }
}
