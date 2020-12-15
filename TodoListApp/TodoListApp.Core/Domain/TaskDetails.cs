namespace TodoListApp.Core.Domain
{
    public class TaskDetails
    {
        public int TaskDetailsId { get; private set; }
        public string TaskDetailName { get; private set; }
        public string Description { get; private set; }
        public bool Done { get; private set; }
        public SingleTask SingleTask { get; set; }

        public TaskDetails(string taskDetailName, string description)
        {
            TaskDetailName = taskDetailName;
            Description = description;
        }
    }
}
