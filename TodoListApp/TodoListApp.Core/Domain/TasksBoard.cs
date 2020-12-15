using System.Collections.Generic;


namespace TodoListApp.Core.Domain
{
    public class TasksBoard
    {
        public uint TasksBoardId { get; private set; }
        public string CategoryName { get; private set; }
        public ICollection<SingleTask> Tasks { get; set; }

        public TasksBoard(string catrgoryName)
        {
            CategoryName = catrgoryName;
            Tasks = new HashSet<SingleTask>();
        }
    }
}
