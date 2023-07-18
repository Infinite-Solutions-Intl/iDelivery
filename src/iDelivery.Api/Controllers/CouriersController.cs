using iDelivery.Api.Controllers.Common;
using iDelivery.Api.Utilities;
using iDelivery.Application.Couriers.Assign;
using iDelivery.Application.Couriers.UnAssign;
using iDelivery.Contracts.Couriers;
using iDelivery.Domain.Common.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[Authorize(Policy = Policies.SupervisorOnly)]
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
        Guid accountId = Auth.GetAccountId(Request.Headers);
        AssignCommand courier = new (accountId, courierId, commandId);
        var response = await _sender.Send(courier);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok(response);
    }

    [HttpDelete("{courierId}/delivery/{deliveryId}")]
    public async Task<IActionResult> DeleteDeliveryAsync(Guid courierId, Guid deliveryId)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        UnAssignCourierCommand courier = new (accountId, courierId, deliveryId);
        var response = await _sender.Send(courier);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok(response);
    }
}
