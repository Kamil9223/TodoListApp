using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Users.Commands
{
    public class RegisterUserCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
