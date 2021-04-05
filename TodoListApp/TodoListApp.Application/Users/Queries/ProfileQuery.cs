using MediatR;
using TodoListApp.Application.Users.ViewModels;

namespace TodoListApp.Application.Users.Queries
{
    public class ProfileQuery : IRequest<ProfileViewModel>
    {
        public int userId { get; set; }
    }
}
