using MediatR;
using TodoListApp.Application.Boards.DTO;

namespace TodoListApp.Application.Boards.Queries
{
    public class BoardQuery : IRequest<BoardDto>
    {
        public int userId { get; set; }
    }
}
