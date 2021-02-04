using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using TodoListApp.Persistance.Context;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration
{
    public class InitialDbDataCreator
    {
        public static void Seed(TodoTasksContext todoTasksContext)
        {
            var pathToTestData = Path.Combine("DatabaseIntegration", "DatabaseConfiguration", "TestData.sql");
            var data = File.ReadAllText(pathToTestData);
            todoTasksContext.Database.ExecuteSqlRaw(data);
        }
    }
}
