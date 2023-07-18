using iDelivery.Api.Controllers.Common;
using iDelivery.Api.Utilities;
using iDelivery.Application.Users.Add;
using iDelivery.Application.Users.Delete;
using iDelivery.Application.Users.Get;
using iDelivery.Application.Users.UpdateRole;
using iDelivery.Contracts.Users;
using iDelivery.Domain.Common.Utilities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

public class UsersController : ApiBaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public UsersController(
        ISender sender,
        IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Policy = Policies.AdminAndSupervisorOnly)]
    public async Task<IActionResult> GetAll()
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        var query= new GetUsersQuery(accountId);
        var result = await _sender.Send(query);
        return Ok(result.Value);
    }

    [HttpPost]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> AddUser(UserDto userDto)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        AddUserCommand command = _mapper.Map<AddUserCommand>((accountId, userDto));
        // var command = new AddUserCommand(
        //     userDto.Email,
        //     accountId,
        //     userDto.Password,
        //     userDto.Name,
        //     userDto.PhoneNumber,
        //     userDto.CountryIdentifier,
        //     userDto.Role,
        //     userDto.SupervisorId,
        //     userDto.PoBox);

        var result = await _sender.Send(command);
        return Ok(result.Value);
    }

    [HttpPut("roles/{userId}")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> ChangeRole(Guid userId, [FromBody] UpdateRoleRequest updateRoleDto)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        ChangeRoleCommand command = _mapper.Map<ChangeRoleCommand>((accountId, userId, updateRoleDto));
        // var command = new ChangeRoleCommand(
        //     accountId,
        //     userId,
        //     updateRoleDto.PreviousRole,
        //     updateRoleDto.NewRole,
        //     updateRoleDto.SupervisorId,
        //     updateRoleDto.PoBox);
        
        var result = await _sender.Send(command);
        if(result.IsFailed)
            return BadRequest();

        return Ok(result.Value);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = Policies.AdminOnly)]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        var command = new DeleteUserCommand(accountId, id);
        var result = await _sender.Send(command);
        if(result.IsFailed)
            return BadRequest();

        return Ok(result.Value);
    }
}
