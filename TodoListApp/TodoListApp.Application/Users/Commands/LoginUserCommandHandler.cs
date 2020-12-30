using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Services.Abstractions;

namespace TodoListApp.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
    {
        private readonly ILoginService _loginService;

        public LoginUserCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            await _loginService.LogIn(request);

            return Unit.Value;
        }
    }
}
