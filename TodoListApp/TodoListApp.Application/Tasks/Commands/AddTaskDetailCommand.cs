using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Tasks.Commands
{
    public class AddTaskDetailCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int TaskId { get; set; }
        public string TaskDetailName { get; set; }
        public string TaskDetailDescription { get; set; }
    }
}
