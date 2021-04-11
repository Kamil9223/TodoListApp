using MediatR;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskDetailCommand : IRequest
    {
        public int TaskId { get; set; }
        public int TaskDetailId { get; set; }
    }
}
