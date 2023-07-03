namespace iDelivery.Api.Utilities;

public static class Auth
{
    public static Guid? GetAccountId(IHeaderDictionary headers)
    {
        string? accountIdString = headers[HeaderKeys.AccountIdHeaderKey];
        if(accountIdString == null)
            return null;

        Guid accountId = Guid.Parse(accountIdString);
        return accountId;
    }
}
