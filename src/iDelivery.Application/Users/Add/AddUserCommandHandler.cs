using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.ManagerAggregate;
using iDelivery.Domain.SupervisorAggregate;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Application.Users.Add;

public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<UserResponse>>
{
    private readonly IAccountRepository _accountRepository;

    public AddUserCommandHandler(
        IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Result<UserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        Account? account = await _accountRepository.GetByIdAsync(accountId, cancellationToken);
        if (account is null)
            return Result.Fail(new BaseError(""));

        Email email = Email.Create(request.Email);
        bool exists = await _accountRepository.ExistsUserAsync(accountId, email, cancellationToken);
        if(exists)
            return Result.Fail(new BaseError("This email is already used by another user"));

        User? user = request.Role.ToLower() switch
        {
            Roles.Admin => CreateAdmin(request),
            Roles.Supervisor => CreateSupervisor(request),
            Roles.Courier => CreateCourier(request),
            Roles.Manager => CreateManager(request),
            Roles.Partner => CreatePartner(request),
            _ => CreatePartner(request)
        };

        if(user is null)
            return Result.Fail(new BaseError("The user could not be created"));

        var success = await _accountRepository.AddUserAsync(account, user, cancellationToken);
        if (!success)
            return Result.Fail(new BaseError("An error occurred while attempting to save the user to the database"));

        return new UserResponse(
                user.Id.Value,
                user.AccountId.Value,
                user.Email.Value,
                user.Password.Value,
                user.Name,
                user.PhoneNumber.Value,
                user.Role,
                request.SupervisorId,
                request.PoBox
            );
    }

    #region Helper methods
    private static Partner CreatePartner(AddUserCommand request)
    {
        return Partner.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            request.PoBox ?? string.Empty,
            AccountId.Create(request.AccountId));
    }

    private static Manager CreateManager(AddUserCommand request)
    {
        return Manager.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            AccountId.Create(request.AccountId));
    }

    private static Supervisor CreateSupervisor(AddUserCommand request)
    {
        return Supervisor.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            AccountId.Create(request.AccountId));
    }

    private static User CreateAdmin(AddUserCommand request)
    {
        return User.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            Roles.Admin,
            AccountId.Create(request.AccountId)
        );
    }

    private static Courier? CreateCourier(AddUserCommand request)
    {
        if (request.SupervisorId is null)
            return null;
        return Courier.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            SupervisorId.Create(request.SupervisorId ?? throw new Exception("The supervisor id is mandatory in ode to create a courier")),
            AccountId.Create(request.AccountId));
    }
    #endregion
}
