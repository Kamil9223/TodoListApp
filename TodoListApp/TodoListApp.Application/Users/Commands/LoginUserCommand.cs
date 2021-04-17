using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Users.Commands
{
    public class LoginUserCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
