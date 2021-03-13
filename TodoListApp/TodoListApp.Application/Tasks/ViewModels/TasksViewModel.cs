using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Tasks.ViewModels
{
    public class TasksViewModel
    {
        public int BoardId { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}
