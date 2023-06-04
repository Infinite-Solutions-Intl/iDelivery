namespace iDelivery.Application.Authentication.Login;

public sealed class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(q => q.Email).NotEmpty();
        RuleFor(q => q.Password)
            .NotEmpty()
            // .Matches("")
            .MinimumLength(6);
    }
}
