using MediatR;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TaskDetailsQuery : IRequest<TaskInfoWithDetailsDto>
    {
        public int TaskId { get; set; }
    }
}
