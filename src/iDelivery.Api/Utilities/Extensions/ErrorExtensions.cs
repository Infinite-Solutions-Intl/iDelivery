using System.Diagnostics;
using FluentResults;
using iDelivery.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Utilities.Extensions;

public static class ErrorExtensions
{
    private static readonly Dictionary<int, (string, string)> _titles = new()
    {
        [StatusCodes.Status400BadRequest] = ("Invalid syntax - The request cannot be understood due to incorrect formatting", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"),
        [StatusCodes.Status401Unauthorized] = ("Authentication required - User authentication is needed to proceed with the request", ""),
        [StatusCodes.Status403Forbidden] = ("Access denied - The requested resource cannot be accessed due to lack of permission", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3"),
        [StatusCodes.Status404NotFound] = ("Resource not found - The requested resource does not exist on the system", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"),
        [StatusCodes.Status409Conflict] = ("Resource conflict - The request could not be completed due to a conflict with the current state of the resource", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8"),
        [StatusCodes.Status500InternalServerError] = ("Internal server error - An error occurred while processing your request", "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"),
    };

    public static ProblemDetails ToProblemDetails(this IEnumerable<IError> errors, HttpContext? context = default)
    {
        var error = errors.First();
        int status = error switch 
        {
            BaseError => StatusCodes.Status500InternalServerError,
            BadCredentialsError => StatusCodes.Status400BadRequest,
            CommandNorFoundError => StatusCodes.Status404NotFound,
            EmailAlreadyExistsError => StatusCodes.Status409Conflict,
            OperationFailedError => StatusCodes.Status500InternalServerError,
            UserNotFoundError => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        (string title, string type) = _titles[status];

        var problemDetails = new ProblemDetails()
        {
            Type = type,
            Title = title,
            Status = status,
            Detail = error.Message,
        };

        problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? context?.TraceIdentifier ?? Guid.NewGuid().ToString());

        if (error.Reasons.Any())
        {
            string[] reasons = error.Reasons.Select(reason => reason.Message).ToArray();
            problemDetails.Extensions.Add("reasons", reasons);
        }

        foreach (var data in error.Metadata)
            problemDetails.Extensions.Add(data.Key, data.Value);


        return problemDetails;
    }
};
