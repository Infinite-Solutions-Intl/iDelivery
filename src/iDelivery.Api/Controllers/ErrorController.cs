using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult CatchError()
    {
        return Problem();
    }
}
