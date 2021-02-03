using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Users.DTO
{
    public class MainPanelDto
    {
        public Dictionary<int, string> Categories { get; set; }
        public List<MainPanelTasksDto> Tasks { get; set; }

    }
}
