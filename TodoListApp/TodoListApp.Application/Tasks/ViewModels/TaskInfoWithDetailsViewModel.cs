using System;
using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.ViewModels
{
    public class TaskInfoWithDetailsViewModel
    {
        public int SingleTaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PredictedFinishDate { get; set; }
        public List<TaskDetailsDto> Details { get; set; }
    }
}
