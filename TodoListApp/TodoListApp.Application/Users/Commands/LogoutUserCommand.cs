using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Users.Commands
{
    public class LogoutUserCommand : BaseCommand, IRequest<ErrorResponse>
    {

    }
}
