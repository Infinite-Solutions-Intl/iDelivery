namespace iDelivery.Application.Users.Get;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<IReadOnlyList<GetUsersQueryResponse>>>
{
    private readonly IAccountRepository _accountReository;
    public GetUsersQueryHandler(IAccountRepository accountReository)
    {
        _accountReository = accountReository;
    }

    public async Task<Result<IReadOnlyList<GetUsersQueryResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        var users = await _accountReository.GetAllUsersAsync(accountId, cancellationToken);
        return users
            .Select(
                u => new GetUsersQueryResponse(
                    u.Email.Value,
                    u.AccountId.Value,
                    u.Password.Value,
                    u.Name,
                    u.PhoneNumber.Value,
                    u.Role,
                    null,
                    null)).ToArray();
    }
}
