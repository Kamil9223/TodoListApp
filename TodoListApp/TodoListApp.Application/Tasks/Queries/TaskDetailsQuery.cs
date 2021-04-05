using MediatR;
using TodoListApp.Application.Tasks.ViewModels;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TaskDetailsQuery : IRequest<TaskInfoWithDetailsViewModel>
    {
        public int TaskId { get; set; }
    }
}
