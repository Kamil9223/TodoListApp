using MediatR;
using TodoListApp.Application.Users.DTO;

namespace TodoListApp.Application.Users.Queries
{
    public class ProfileQuery : IRequest<ProfileDto>
    {
        public int userId { get; set; }
    }
}
