using FluentValidation;
using TodoListApp.Application.Users.Commands;

namespace TodoListApp.Infrastructure.API.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(80);

            RuleFor(x => x.Password)
                .MaximumLength(5)
                .MaximumLength(20)
                .NotNull();
        }
    }
}
