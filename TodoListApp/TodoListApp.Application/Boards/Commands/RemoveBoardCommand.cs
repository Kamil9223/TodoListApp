using MediatR;

namespace TodoListApp.Application.Boards.Commands
{
    public class RemoveBoardCommand : IRequest
    {
        public int BoardId { get; set; }
    }
}
