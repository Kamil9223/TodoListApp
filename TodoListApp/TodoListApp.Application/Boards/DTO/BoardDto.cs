using System.Collections.Generic;
using TodoListApp.Application.Tasks.DTO;

namespace TodoListApp.Application.Boards.DTO
{
    public class BoardDto
    {
        public Dictionary<int, string> Categories { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public int ActualBoardId { get; set; }
    }
}
