using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration;
using TodoListApp.Persistance.DataAccess;
using Xunit;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.Tests
{
    [Collection(DatabaseFixture.DbCollection)]
    public class TasksBoardRepositoryTest
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly ITasksBoardRepository _boardRepository;

        public TasksBoardRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _boardRepository = new TasksBoardRepository(_databaseFixture.TodoTasksContext);
        }

        [Fact]
        public async Task Should_returns_boards_with_tasks()
        {
            var boards = await _boardRepository.GetAllWithTasks(1);

            boards.Should().NotBeNull();
            boards.Should().HaveCount(2);
            boards.First().Tasks.Should().HaveCount(2);
        }
    }
}
