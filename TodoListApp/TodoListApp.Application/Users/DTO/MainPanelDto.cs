using System.Collections.Generic;
using TodoListApp.Core.Domain;

namespace TodoListApp.Application.Users.DTO
{
    public class MainPanelDto
    {
        public int FirstBoardId { get; set; }
        public List<string> CategoryNames { get; set; }
        public List<MainPanelTasksDto> Tasks { get; set; }

    }

    public class MainPanelTasksDto
    {
        public int SingleTaskId { get; set; }
        public string TaskName { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool PredictedBestBeforeDateExceeded { get; set; }
    }
}
