using MediatR;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQuery : IRequest<TasksCollectionDto>
    {
        public int TasksBoardId { get; set; }
    }
}
