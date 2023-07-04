namespace iDelivery.Api.Utilities;

public static class Auth
{
    public static Guid GetAccountId(IHeaderDictionary headers)
    {
        string? accountIdString = headers[HeaderKeys.AccountIdHeaderKey];
        if(accountIdString == null)
            throw new Exception($"The {HeaderKeys.AccountIdHeaderKey} header does not exist in this request context");

        Guid accountId = Guid.Parse(accountIdString);
        return accountId;
    }
}
