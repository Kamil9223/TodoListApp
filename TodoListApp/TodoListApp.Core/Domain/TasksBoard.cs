using System.Collections.Generic;


namespace TodoListApp.Core.Domain
{
    public class TasksBoard : IEntity
    {
        public int TasksBoardId { get; private set; }
        public string CategoryName { get; private set; }
        public User User { get; set; }
        public ICollection<SingleTask> Tasks { get; set; }

        public TasksBoard(string categoryName)
        {
            CategoryName = categoryName;
            Tasks = new HashSet<SingleTask>();
        }
    }
}
