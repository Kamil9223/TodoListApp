using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Users.Commands
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, ErrorResponse>
    {
        private readonly IHttpContextAccessor _httpAccessor;

        public LogoutUserCommandHandler(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        public async Task<ErrorResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _httpAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return request.ErrorModel;
        }
    }
}
