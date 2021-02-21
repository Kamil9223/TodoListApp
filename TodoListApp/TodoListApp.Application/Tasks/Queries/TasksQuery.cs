using MediatR;
using System.Collections.Generic;
using TodoListApp.Application.Boards.DTO;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQuery : IRequest<List<TaskDto>>
    {
        public int TasksBoardId { get; set; }
    }
}
