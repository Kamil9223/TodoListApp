using FluentValidation;
using TodoListApp.Application.Users.Commands;

namespace TodoListApp.Application.Users.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(80);

            RuleFor(x => x.Password)
                .MinimumLength(5)
                .MaximumLength(20)
                .NotNull();
        }
    }
}
