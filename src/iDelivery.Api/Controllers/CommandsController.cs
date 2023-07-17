using iDelivery.Api.Controllers.Common;
using iDelivery.Api.Filters;
using iDelivery.Api.Utilities;
using iDelivery.Application.Commands.Add;
using iDelivery.Application.Commands.Get.All;
using iDelivery.Application.Commands.Get.Single;
using iDelivery.Application.Commands.Update.UpdateDetails;
using iDelivery.Application.Commands.Update.UpdateStatus;
using iDelivery.Contracts.Commands;
using iDelivery.Domain.CommandAggregate.Enums;
using iDelivery.Domain.Common.Utilities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace iDelivery.Api.Controllers;

[Authorize]
public class CommandsController : ApiBaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CommandsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommands(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        DateTime? startDate,
        DateTime? endDate,
        int? page,
        int? pageSize)
    {
        GetCommandQuery query = new(
            searchTerm,
            sortColumn,
            sortOrder,
            startDate,
            endDate,
            page,
            pageSize);

        var result = await _sender.Send(query);
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleCommands(Guid id)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        GetSingleCommandQuery query = new(id, accountId);
        var result = await _sender.Send(query);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> PostCommand(AddCommandRequest request)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        AddCommand command = _mapper.Map<AddCommand>((accountId, request));
        var response = await _sender.Send(command);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);

        return Ok(response.Value);
    }

    [HttpPut("{id}/{refNum}")]
    public async Task<IActionResult> UpdateCommandDetails(Guid id, string refNum, [FromBody] UpdateCommandRequest request)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        UpdateCommand command = _mapper.Map<UpdateCommand>((id, accountId, refNum, request));
        var response = await _sender.Send(command);
        if (response.IsFailed)
            return BadRequest(response.Errors[0].Message);
        return Ok(response.Value);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = Policies.RunnerOnly)]
    public async Task<IActionResult> UpdateCommandStatus(Guid id, [FromBody] UpdateDeliveryStatus request)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        var command = new UpdateDeliveryStatusCommand(id, accountId, (Status)request.Status);
        var response = await _sender.Send(command);
        if(response.IsFailed)
            return BadRequest(response.Errors[0].Message);
        return Ok(response.Value);
    }
}
