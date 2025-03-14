namespace Api.Controllers.Auth;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull();
        RuleFor(x => x.Password).NotEmpty().NotNull();
    }
}

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull().MinimumLength(4);
        RuleFor(x => x.Password).NotEmpty().NotNull().MinimumLength(4);
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
    }
}
