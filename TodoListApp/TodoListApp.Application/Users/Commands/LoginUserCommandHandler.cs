using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Exceptions;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;
        private readonly IHttpContextAccessor _httpAccessor;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IEncrypter encrypter, IHttpContextAccessor httpAccessor)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
            _httpAccessor = httpAccessor;
        }

        public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Get(request.Email);
            if (user == null)
                throw new InvalidCredentialsException();

            var hash = _encrypter.Encrypt(request.Password);
            if (user.PasswordHash != hash)
                throw new InvalidCredentialsException();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, request.Email),
                new Claim("Id", user.UserId.ToString())
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(claimIdentity);

            await _httpAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = false
                });

            return Unit.Value;
        }
    }
}
