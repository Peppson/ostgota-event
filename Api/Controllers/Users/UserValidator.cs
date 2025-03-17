namespace Api.Controllers.Users;

public class UserValidator : AbstractValidator<UserCreateDTO>
{
    public UserValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull().MinimumLength(4).MaximumLength(40);
        RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().MaximumLength(60);
        RuleFor(x => x.Role).NotNull();
    }
}
