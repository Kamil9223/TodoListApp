using System.Threading.Tasks;
using TodoListApp.Application.Users.Commands;

namespace TodoListApp.Application.Users.Services.Abstractions
{
    public interface ILoginService
    {
        Task LogIn(LoginUserCommand command);
        Task LogOut();
    }
}
