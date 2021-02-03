using System.Collections.Generic;

namespace TodoListApp.Application.Users.DTO
{
    public class MainPanelDto
    {
        public Dictionary<int, string> Categories { get; set; }
        public List<MainPanelTasksDto> Tasks { get; set; }

    }
}
