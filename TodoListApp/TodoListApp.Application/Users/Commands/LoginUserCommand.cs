using MediatR;

namespace TodoListApp.Application.Users.Commands
{
    public class LoginUserCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
