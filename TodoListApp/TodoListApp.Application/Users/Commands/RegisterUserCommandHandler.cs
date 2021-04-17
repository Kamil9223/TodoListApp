using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Exceptions;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IEncrypter encrypter)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmedPassword)
                throw new InvalidCredentialsException("Confirmed password is different than password", "");

            var existedUser = await _unitOfWork.Users.Get(request.Email);
            if (existedUser != null)
                throw new AlreadyExistsException($"User with email: [{request.Email}] already exist.");

            var passwordHash = _encrypter.Encrypt(request.Password);
            var user = new User(request.Email, passwordHash);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
