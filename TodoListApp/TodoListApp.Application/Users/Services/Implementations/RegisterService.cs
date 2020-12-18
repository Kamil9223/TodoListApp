using System;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Commands;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;

        public RegisterService(IUnitOfWork unitOfWork, IEncrypter encrypter)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
        }

        public async Task Register(RegisterUserCommand command)
        {
            if (command.Password != command.ConfirmedPassword)
                throw new Exception();//TODO

            var existedUser = await _unitOfWork.Users.Find(x => x.Email == command.Email);
            if (existedUser != null)
                throw new Exception();//TODO

            var passwordHash = _encrypter.Encrypt(command.Password);
            var user = new User(command.Email, passwordHash);

            await _unitOfWork.Users.Add(user);
            await _unitOfWork.Complete();
        }
    }
}
