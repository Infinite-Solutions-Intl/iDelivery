using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult CatchError()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null)
            return Problem();

        var problemDetail = new ProblemDetails
        {
            Detail = exception.Message,
            Status = 500,
            Title = exception.GetType().Name,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = "/error"
        };

        problemDetail.Extensions.Add("traceId", Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        return new ObjectResult(problemDetail);
    }
}
