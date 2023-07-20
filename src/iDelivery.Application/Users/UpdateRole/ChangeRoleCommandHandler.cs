namespace iDelivery.Application.Users.UpdateRole;

public sealed class ChangeRoleCommandHandler : IRequestHandler<ChangeRoleCommand, Result<UserResponse>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public ChangeRoleCommandHandler(
        IAccountRepository accountRepository,
        IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
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
            return Result.Fail<UserResponse>(new UserNotFoundError(userId.Value.ToString()));
        return _mapper.Map<UserResponse>(user);
    }
}
