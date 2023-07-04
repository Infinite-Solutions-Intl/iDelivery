using iDelivery.Api.Controllers.Common;
using iDelivery.Api.Utilities;
using iDelivery.Application.Users.Add;
using iDelivery.Application.Users.Get;
using iDelivery.Contracts.Users;
using iDelivery.Domain.Common.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[Authorize(Policy = Policies.AdminOnly)]
public class UsersController : ApiBaseController
{
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        var query= new GetUsersQuery(accountId);
        var result = await _sender.Send(query);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDto userDto)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        var command = new AddUserCommand(
            userDto.Email,
            accountId,
            userDto.Password,
            userDto.Name,
            userDto.PhoneNumber,
            userDto.CountryIdentifier,
            userDto.Role,
            userDto.SupervisorId,
            userDto.PoBox);

        var result = await _sender.Send(command);
        return Ok(result.Value);
    }
}
