using System;
using System.Collections.Generic;

namespace TodoListApp.Application.Tasks.DTO
{
    public class TaskInfoWithDetailsDto
    {
        public int SingleTaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PredictedFinishDate { get; set; }
        public List<TaskDetailsDto> Details { get; set; }
    }
}
