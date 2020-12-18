using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
