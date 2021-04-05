using MediatR;
using TodoListApp.Application.Boards.ViewModels;

namespace TodoListApp.Application.Boards.Queries
{
    public class BoardQuery : IRequest<BoardViewModel>
    {
        public int UserId { get; set; }
        public int BoardId { get; set; }
    }
}
