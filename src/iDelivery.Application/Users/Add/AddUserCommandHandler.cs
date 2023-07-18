using iDelivery.Application.Commands;
using iDelivery.Domain.CommandAggregate;
using iDelivery.Domain.Common.Utilities;
using iDelivery.Domain.CourierAggregate;
using iDelivery.Domain.ManagerAggregate;
using iDelivery.Domain.SupervisorAggregate;
using iDelivery.Domain.SupervisorAggregate.ValueObjects;

namespace iDelivery.Application.Users.Add;

public sealed class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<UserResponse>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AddUserCommandHandler(
        IAccountRepository accountRepository,
        IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<Result<UserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        AccountId accountId = AccountId.Create(request.AccountId);
        Email email = Email.Create(request.Email);
        bool exists = await _accountRepository.ExistsUserAsync(accountId, email, cancellationToken);
        if(exists)
            return Result.Fail(new BaseError("This email is already used by another user"));

        User? user = request.Role.ToLower() switch
        {
            Roles.Admin => await CreateAdminAsync(request),
            Roles.Supervisor => await CreateSupervisorAsync(request),
            Roles.Courier => await CreateCourierAsync(request),
            Roles.Manager => await CreateManagerAsync(request),
            Roles.Partner => await CreatePartnerAsync(request),
            _ => await CreatePartnerAsync(request)
        };

        if(user is null)
            return Result.Fail(new BaseError("The user could not be created"));

        var success = await _accountRepository.AddUserAsync(accountId, user, cancellationToken);
        if (!success)
            return Result.Fail(new BaseError("An error occurred while attempting to save the user to the database"));

        return _mapper.Map<UserResponse>(user);
    }

    #region Helper methods
    private static async Task<Partner> CreatePartnerAsync(AddUserCommand request)
    {
        await Task.CompletedTask;
        return Partner.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            request.PoBox ?? string.Empty,
            AccountId.Create(request.AccountId));
    }

    private static async Task<Manager> CreateManagerAsync(AddUserCommand request)
    {
        await Task.CompletedTask;
        return Manager.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            AccountId.Create(request.AccountId));
    }

    private static async Task<Supervisor> CreateSupervisorAsync(AddUserCommand request)
    {
        await Task.CompletedTask;
        return Supervisor.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            AccountId.Create(request.AccountId));
    }

    private static async Task<User> CreateAdminAsync(AddUserCommand request)
    {
        await Task.CompletedTask;
        return User.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            Roles.Admin,
            AccountId.Create(request.AccountId)
        );
    }

    private async Task<Courier?> CreateCourierAsync(AddUserCommand request)
    {
        if (request.SupervisorId is null)
            return null;

        AccountId accountId = AccountId.Create(request.AccountId);
        SupervisorId supervisorId = SupervisorId.Create(request.SupervisorId ?? throw new Exception("The supervisor id is mandatory in ode to create a courier"));
        bool exists = await _accountRepository.ExistsUserAsync(accountId, supervisorId);

        if(!exists)
            throw new Exception("");

        return Courier.Create(
            Email.Create(request.Email),
            Password.Create(request.Password),
            request.Name,
            PhoneNumber.Create(request.PhoneNumber, request.CountryIdentifier),
            supervisorId,
            accountId);
    }
    #endregion
}
