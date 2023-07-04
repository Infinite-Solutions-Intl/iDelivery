using FluentResults;
using iDelivery.Application.Authentication.Login;
using iDelivery.Application.Authentication.Register;
using iDelivery.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
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

    [HttpPost("login")] 
    public async Task<IActionResult> Login(LoginREquestDto request)
    {
        LoginQuery command = _mapper.Map<LoginQuery>(request);
        Result<LoginQueryResponse> result = await _sender.Send(command);

        if(result.IsFailed)
            return Problem();

        return Ok(result.Value);
    }
}
