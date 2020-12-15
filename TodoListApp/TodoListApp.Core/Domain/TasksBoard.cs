﻿using System.Collections.Generic;


namespace TodoListApp.Core.Domain
{
    public class TasksBoard
    {
        public int TasksBoardId { get; private set; }
        public string CategoryName { get; private set; }
        public User User { get; set; }
        public ICollection<SingleTask> Tasks { get; set; }

        public TasksBoard(string catrgoryName)
        {
            CategoryName = catrgoryName;
            Tasks = new HashSet<SingleTask>();
        }
    }
}
