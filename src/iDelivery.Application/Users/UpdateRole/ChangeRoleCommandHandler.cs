namespace iDelivery.Application.Users.UpdateRole;

public sealed class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand, Result<UserResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public ChangeRoleCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result<UserResponse>> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        UserId userId = UserId.Create(request.UserId);

        User? user = await _accountRepository.ChangeRoleAsync(
            accountId,
            userId,
            request.PreviousRole,
            request.NewRole,
            request.SupervisorId,
            request.PoBox,
            cancellationToken);

        if(user is null)
            return Result.Fail(new BaseError(""));

        return new UserResponse(
            user.Id.Value,
            user.AccountId.Value,
            user.Email.Value,
            user.Password.Value,
            user.Name,
            user.PhoneNumber.Value,
            user.Role,
            null,
            null
        );
    }
}
