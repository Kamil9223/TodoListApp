using System.Collections.Generic;
using TodoListApp.Application.Boards.DTO;

namespace TodoListApp.Application.Users.DTO
{
    public class MainPanelDto
    {
        public Dictionary<int, string> Categories { get; set; }
        public List<MainPanelTasksDto> Tasks { get; set; }

    }
}
