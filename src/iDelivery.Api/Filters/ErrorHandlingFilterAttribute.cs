using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iDelivery.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is null)
        {
            return;
        }
        var problem = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "An error occurred while processing your request.",
            Detail = context.Exception.Message,
            Status = 500,
            Instance = context.HttpContext.Request.Path.ToString()
        };

        context.Result = new ObjectResult(problem);
        context.ExceptionHandled = true;
    }
}
