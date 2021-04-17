using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TodoListApp.Application.Users.Commands
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand>
    {
        private readonly IHttpContextAccessor _httpAccessor;

        public LogoutUserCommandHandler(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        public async Task<Unit> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await _httpAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Unit.Value;
        }
    }
}
