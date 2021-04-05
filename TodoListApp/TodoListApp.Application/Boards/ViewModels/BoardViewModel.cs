using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Boards.ViewModels
{
    public class BoardViewModel
    {
        public Dictionary<int, string> Categories { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public int ActualBoardId { get; set; }
    }
}
