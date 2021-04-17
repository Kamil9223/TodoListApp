using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskDetailCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int TaskId { get; set; }
        public int TaskDetailId { get; set; }
    }
}
