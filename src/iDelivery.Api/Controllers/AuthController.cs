using FluentResults;
using iDelivery.Api.Controllers.Common;
using iDelivery.Application.Authentication.Register;
using iDelivery.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

public class AuthController : ApiBaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthController(
        ISender sender,
        IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        RegisterCommand command = _mapper.Map<RegisterCommand>(request);
        Result<RegisterCommandResponse> result = await _sender.Send(command);

        if(result.IsFailed)
            return Problem();

        return Ok(result.Value);
    }
}
