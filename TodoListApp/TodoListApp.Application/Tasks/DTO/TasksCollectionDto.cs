using System.Collections.Generic;
using TodoListApp.Application.Users.DTO;

namespace TodoListApp.Application.Tasks.DTO
{
    public class TasksCollectionDto
    {
        public List<MainPanelTasksDto> Tasks { get; set; }
    }
}
