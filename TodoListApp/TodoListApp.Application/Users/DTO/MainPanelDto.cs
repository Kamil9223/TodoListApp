using System.Collections.Generic;

namespace TodoListApp.Application.Users.DTO
{
    public class MainPanelDto
    {
        public List<string> CategoryNames { get; set; }
        public List<MainPanelTasksDto> Tasks { get; set; }

    }
}
