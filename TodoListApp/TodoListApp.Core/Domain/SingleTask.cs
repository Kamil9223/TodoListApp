using System;
using System.Collections.Generic;

namespace TodoListApp.Core.Domain
{
    public class SingleTask
    {
        public uint SingleTaskId { get; private set; }
        public string TaskName { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime PredictedFinishDate { get; private set; }
        public PriorityLevel Priority { get; private set; }
        public ICollection<TaskDetails> Details { get; set; }

        public SingleTask(string taskName, DateTime createdAt, DateTime predictedFinishDate, 
            PriorityLevel priority)
        {
            TaskName = taskName;
            CreatedAt = createdAt;
            PredictedFinishDate = predictedFinishDate;
            Priority = priority;
            Details = new HashSet<TaskDetails>();
        }
    }

    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
}
