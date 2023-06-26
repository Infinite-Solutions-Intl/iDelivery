using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Commands.Add;
using iDelivery.Application.Commands.Get;
using iDelivery.Contracts.Commands;
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
    public IActionResult PutCommand(Guid id, string refNum, [FromBody] UpdateCommandRequest updateCommand)
    {
        return Ok(updateCommand);
    }

    [HttpPut("{id}")]
    public IActionResult PutCommand(Guid id, [FromBody] UpdateDeliveryStatus request)
    {
        return Ok(request);
    }

    [HttpGet]
    public async Task<IActionResult> GetCommands()
    {
        GetQuery query = new();
        var result = await _sender.Send(query);
        return Ok(result.Value);
    }
}
