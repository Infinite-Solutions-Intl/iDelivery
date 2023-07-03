namespace iDelivery.Application.Users.Get;

public sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<IReadOnlyList<GetUsersQueryResponse>>>
{
    private readonly IUserRepository _userRepository;
    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IReadOnlyList<GetUsersQueryResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        var users = await _userRepository.GetAllAsync(accountId, cancellationToken);
        return users.Select(u => new GetUsersQueryResponse(u.Name)).ToArray();
    }
}
