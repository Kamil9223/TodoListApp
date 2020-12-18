using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Services.Abstractions;

namespace TodoListApp.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IRegisterService _registerService;

        public RegisterUserCommandHandler(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await _registerService.Register(request);

            return Unit.Value;
        }
    }
}
