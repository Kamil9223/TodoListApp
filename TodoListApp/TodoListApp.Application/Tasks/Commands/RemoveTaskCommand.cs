using MediatR;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskCommand : IRequest
    {
        public int TaskId { get; set; }
        public int BoardId { get; set; }
    }
}
