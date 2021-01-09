using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Services.Abstractions;

namespace TodoListApp.Application.Users.Commands
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly ILoginService _loginService;

        public LogoutUserCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _loginService.LogOut();

            return Unit.Value;
        }
    }
}
