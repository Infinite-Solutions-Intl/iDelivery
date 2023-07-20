using iDelivery.Api.Utilities;
using iDelivery.Application.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace iDelivery.Api.Filters;

public class ApiKeyAuthorizeAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if(!context.HttpContext.Request.Headers.TryGetValue(HeaderKeys.ApiKeyHeaderKey, out var apiKey))
        {
            var problemDetail = new ProblemDetails()
            {
                Title = "Authentication required - User authentication is needed to proceed with the request",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "User authentication is needed to proceed with the request"
            };
            problemDetail.Extensions.Add("reasons", new[] { $"{HeaderKeys.ApiKeyHeaderKey} header key is missing"});
            problemDetail.Extensions.Add("hints", new[] { $"Add {HeaderKeys.ApiKeyHeaderKey} key to the headers is required to proceed with the request", "This header should contain the value of the API key provided at registration" });
            context.Result = new ObjectResult(problemDetail);
            return;
        }

        (bool isValid, Guid accountId) = await IsValidKeyAsync(apiKey!, context);
        if(!isValid)
        {
            var problemDetail = new ProblemDetails()
            {
                Title = "Authentication required - User authentication is needed to proceed with the request",
                Status = StatusCodes.Status401Unauthorized,
                Detail = "The provided API key is not valid",
            };
            problemDetail.Extensions.Add("reasons", new string[] { "The provided API key may either be expired or corrupted"});
            context.Result = new ObjectResult(problemDetail);
            return;
        }

        context.HttpContext.Request.Headers.Add(HeaderKeys.AccountIdHeaderKey, accountId.ToString());
        await next();
    }

    private static Task<(bool success, Guid accountId)> IsValidKeyAsync(string key, ActionExecutingContext context)
    {
        var accountRepository = context.HttpContext.RequestServices.GetRequiredService<IAccountRepository>();
        return accountRepository.IsValidKeyAsync(key);
    }
}
