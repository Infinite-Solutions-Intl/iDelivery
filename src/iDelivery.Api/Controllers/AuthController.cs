using iDelivery.Application.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request)
    {
        RegisterCommandResponse response = await _sender.Send(request);
        return Ok(response);
    }
}
