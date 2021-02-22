using System;
using System.Collections.Generic;
using TodoListApp.Core.Domain;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public class TaskRepositoryTestData
    {
        public static IEnumerable<SingleTask> CreateTasks()
        {
            return new List<SingleTask>
            {
                new SingleTask(1, "sprzątanie pokoju", DateTime.Now, DateTime.Now.AddDays(1), PriorityLevel.Medium),
                new SingleTask(2, "przeczytanie książki", DateTime.Now, DateTime.Now.AddDays(7), PriorityLevel.Low),
                new SingleTask(3, "kupno zapałek", DateTime.Now, DateTime.Now.AddDays(1), PriorityLevel.High)
            };
        }
    }
}
