using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TodoListApp.Core.Domain;
using TodoListApp.Persistance.Context;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration
{
    public class DatabaseFixture : IDisposable
    {
        public const string DbCollection = "Test Database Collection";

        public TodoTasksContext TodoTasksContext { get; }
        private readonly SqliteConnection _connection;

        public DatabaseFixture()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var dbOption = new DbContextOptionsBuilder<TodoTasksContext>()
                .UseSqlite(_connection)
                .Options;

            TodoTasksContext = new TodoTasksContext(dbOption);
            TodoTasksContext.Database.EnsureCreated();

            InitialDbDataCreator.Seed(TodoTasksContext);
        }

        public void Clear<T>(T entity) where T : class, IEntity
        {
            TodoTasksContext.Set<T>().Remove(entity);
            TodoTasksContext.SaveChanges();
        }

        public void Clear<T>(IEnumerable<T> entities) where T: class, IEntity
        {
            TodoTasksContext.Set<T>().RemoveRange(entities);
            TodoTasksContext.SaveChanges();
        }

        public void Dispose()
        {
            TodoTasksContext.Database.EnsureDeleted();
            TodoTasksContext.Dispose();
            _connection.Dispose();
        }
    }
}
