using Microsoft.EntityFrameworkCore;
using System;
using TodoListApp.Persistance.Context;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.Tests
{
    public abstract class TestBase
    {
        protected TodoTasksContext CreateInMemoryDbContext()
        {
            var dbOption = new DbContextOptionsBuilder<TodoTasksContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new TodoTasksContext(dbOption);
        }
    }
}
