namespace iDelivery.Application.Users.Get;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<IReadOnlyList<UserResponse>>>
{
    private readonly IAccountRepository _accountRepository;
    public GetUsersQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result<IReadOnlyList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        var users = await _accountRepository.GetAllUsersAsync(accountId, cancellationToken);
        return users
            .Select(
                u => new UserResponse(
                    u.Id.Value,
                    u.AccountId.Value,
                    u.Email.Value,
                    u.Password.Value,
                    u.Name,
                    u.PhoneNumber.Value,
                    u.Role,
                    null,
                    null)).ToArray();
    }
}
