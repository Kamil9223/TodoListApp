using MediatR;
using TodoListApp.Application.Tasks.ViewModels;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQuery : IRequest<TasksViewModel>
    {
        public int TasksBoardId { get; set; }
    }
}
