using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace iDelivery.Api.Services;

public class ErrorHandler
{
    public static IResult Handle(HttpContext context)
    {
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        int code = exception switch
        {
            ArgumentNullException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        return Results.Problem(exception?.Message, statusCode: code);
    }
}
