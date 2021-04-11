using MediatR;

namespace TodoListApp.Application.Tasks.Commands
{
    public class AddTaskDetailCommand : IRequest
    {
        public int TaskId { get; set; }
        public string TaskDetailName { get; set; }
        public string TaskDetailDescription { get; set; }
    }
}
