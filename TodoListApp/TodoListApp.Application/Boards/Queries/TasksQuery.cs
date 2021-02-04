using MediatR;
using System.Collections.Generic;
using TodoListApp.Application.Boards.DTO;

namespace TodoListApp.Application.Boards.Queries
{
    public class TasksQuery : IRequest<List<MainPanelTasksDto>>
    {
        public int TasksBoardId { get; set; }
    }
}
