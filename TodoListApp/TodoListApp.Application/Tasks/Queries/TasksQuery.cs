using MediatR;
using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQuery : IRequest<List<MainPanelTasksDto>>
    {
        public int TasksBoardId { get; set; }
    }
}
