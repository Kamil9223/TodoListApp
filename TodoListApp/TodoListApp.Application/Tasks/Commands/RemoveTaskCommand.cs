using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int TaskId { get; set; }
        public int BoardId { get; set; }
    }
}
