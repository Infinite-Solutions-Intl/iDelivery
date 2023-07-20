using FluentResults;
using iDelivery.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace iDelivery.Api.Utilities.Extensions;

public static class ErrorExtensions
{
    private static readonly Dictionary<int, string> _titles = new()
    {
        [StatusCodes.Status400BadRequest] = " Invalid syntax - The request cannot be understood due to incorrect formatting",
        [StatusCodes.Status401Unauthorized] = "Authentication required - User authentication is needed to proceed with the request",
        [StatusCodes.Status403Forbidden] = "Access denied - The requested resource cannot be accessed due to lack of permission",
        [StatusCodes.Status404NotFound] = "Resource not found - The requested resource does not exist on the system",
        [StatusCodes.Status409Conflict] = "Resource conflict - The request could not be completed due to a conflict with the current state of the resource",
        [StatusCodes.Status500InternalServerError] = "Internal server error - An error occurred while processing your request",
    };

    public static ProblemDetails ToProblemDetails(this IEnumerable<IError> errors)
    {
        var error = errors.First();
        int status = error switch 
        {
            UserNotFoundError => StatusCodes.Status404NotFound,
            EmailAlreadyExistsError => StatusCodes.Status409Conflict,
            BaseError => StatusCodes.Status500InternalServerError,
            _ => StatusCodes.Status500InternalServerError
        };

        string title = _titles[status];

        var problemDetails = new ProblemDetails()
        {
            Title = title,
            Status = status,
            Detail = error.Message,
        };

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
