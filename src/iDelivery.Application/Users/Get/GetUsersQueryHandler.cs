namespace iDelivery.Application.Users.Get;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<IReadOnlyList<UserResponse>>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    public GetUsersQueryHandler(
        IAccountRepository accountRepository,
        IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<Result<IReadOnlyList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        IReadOnlyList<User> users = await _accountRepository.GetAllUsersAsync(accountId, cancellationToken);
        return users
            .Select(
                u => _mapper.Map<UserResponse>(u)).ToArray();
    }
}
