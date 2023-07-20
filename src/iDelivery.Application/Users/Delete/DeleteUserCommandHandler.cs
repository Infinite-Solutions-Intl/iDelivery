namespace iDelivery.Application.Users.Delete;

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<DeleteUserCommandResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public DeleteUserCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result<DeleteUserCommandResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        UserId userId = UserId.Create(request.UserId);

        User? user = await _accountRepository.FindUserAsync(accountId, userId, cancellationToken);
        if(user is null)
            return Result.Fail<DeleteUserCommandResponse>(new BaseError(""));

        int records = await _accountRepository.DeleteUserAsync(accountId, user, cancellationToken);
        return new DeleteUserCommandResponse(records > 0, records);
    }
}
