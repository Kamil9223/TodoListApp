using MediatR;
using TodoListApp.Application.Users.DTO;

namespace TodoListApp.Application.Users.Queries
{
    public class UserBoardQuery : IRequest<MainPanelDto>
    {
        public int userId { get; set; }
    }
}
