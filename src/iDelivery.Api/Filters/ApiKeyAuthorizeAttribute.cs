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
            context.Result = new UnauthorizedResult();
            return;
        }

        (bool isValid, Guid accountId) = await IsValidKeyAsync(apiKey!, context);
        if(!isValid)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        context.HttpContext.Request.Headers.Add(HeaderKeys.AccountIdHeaderKey, accountId.ToString());
        await next();
        return;
    }

    private static Task<(bool success, Guid accountId)> IsValidKeyAsync(string key, ActionExecutingContext context)
    {
        var accountRepository = context.HttpContext.RequestServices.GetRequiredService<IAccountRepository>();
        return accountRepository.IsValidKeyAsync(key);
    }
}
