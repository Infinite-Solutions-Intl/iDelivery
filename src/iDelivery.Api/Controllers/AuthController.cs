using FluentResults;
using iDelivery.Api.Filters;
using iDelivery.Api.Utilities;
using iDelivery.Api.Utilities.Extensions;
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
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        RegisterCommand command = _mapper.Map<RegisterCommand>(request);
        Result<RegisterCommandResponse> result = await _sender.Send(command);
        
        if(result.IsSuccess)
            return Ok(result.Value);

        return new ObjectResult(result.Errors.ToProblemDetails());
    }

    [HttpPost("login")]
    [ApiKeyAuthorize]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        Guid accountId = Auth.GetAccountId(Request.Headers);
        LoginQuery command = _mapper.Map<LoginQuery>((accountId, request));
        Result<LoginQueryResponse> result = await _sender.Send(command);

        if (result.IsSuccess)
            return Ok(result.Value);

        return new ObjectResult(result.Errors.ToProblemDetails());
    }
}
