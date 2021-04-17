using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ErrorResponse>
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

        public async Task<ErrorResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Get(request.Email);
            if (user == null)
            {
                request.ErrorModel.AddModelError(nameof(request.Email), ErrorMessages.EmailNotExists);
                return request.ErrorModel;
            }    

            var hash = _encrypter.Encrypt(request.Password);
            if (user.PasswordHash != hash)
            {
                request.ErrorModel.AddModelError(nameof(request.Password), ErrorMessages.InvalidCredentials);
                return request.ErrorModel;
            }

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

            return request.ErrorModel;
        }
    }
}
