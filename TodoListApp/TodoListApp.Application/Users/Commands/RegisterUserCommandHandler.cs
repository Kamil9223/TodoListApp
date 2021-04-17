using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IEncrypter encrypter)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
        }

        public async Task<ErrorResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password != request.ConfirmedPassword)
            {
                request.ErrorModel.AddModelError(nameof(request.ConfirmedPassword), ErrorMessages.DifferentConfirmedPassword);
                return request.ErrorModel;
            }

            var existedUser = await _unitOfWork.Users.Get(request.Email);
            if (existedUser != null)
            {
                request.ErrorModel.AddModelError(nameof(request.Email), ErrorMessages.EmailElreadyExist);
                return request.ErrorModel;
            }

            var passwordHash = _encrypter.Encrypt(request.Password);
            var user = new User(request.Email, passwordHash);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.Complete();

            return request.ErrorModel;
        }
    }
}
