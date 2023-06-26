using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Commands.Add;
using iDelivery.Application.Commands.Get;
using iDelivery.Application.Commands.Update.Commands;
using iDelivery.Contracts.Commands;
using iDelivery.Domain.CommandAggregate.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace iDelivery.Api.Controllers;
public class CommandsController : ApiBaseController
{
    private readonly ISender _sender;

    public CommandsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommands()
    {
        GetQuery query = new();
        var result = await _sender.Send(query);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> PostCommand(AddCommandRequest request)
    {
        AddCommand command = new (
            request.RefNum,
            request.Intitule,
            request.City,
            request.Quarter,
            request.Latitude,
            request.Longitude,
            request.PreferredDate,
            request.PreferredTime
        );
        var response = await _sender.Send(command);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok(response.Value);
    }

    [HttpPut("{id}/{refNum}")]
    public async Task<IActionResult> PutCommand(Guid id, string refNum, [FromBody] UpdateCommandRequest request)
    {
        var command = new UpdateCommand(
            id,
            refNum,
            request.City,
            request.Quarter,
            request.Longitude,
            request.Latitude,
            request.PreferredDate,
            request.PreferredTime);
        var response = await _sender.Send(command);
        if (response.IsFailed)
            return BadRequest(response.Errors[0].Message);
        return Ok(response.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommand(Guid id, [FromBody] UpdateDeliveryStatus request)
    {
        var command = new UpdateDeliveryStatusCommand(id, (Status) request.Status);
        var response = await _sender.Send(command);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);
        return Ok(response.Value);
    }
}
