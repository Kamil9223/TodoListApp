using TodoListApp.Core.Domain;

namespace TodoListApp.Application.Tasks.DTO
{
    public class TaskDto
    {
        public int SingleTaskId { get; set; }
        public string TaskName { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool PredictedBestBeforeDateExceeded { get; set; }
    }
}
