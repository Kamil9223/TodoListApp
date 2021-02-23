using FluentAssertions;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration;
using TodoListApp.Persistance.DataAccess;
using Xunit;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.Tests
{
    [Collection(DatabaseFixture.DbCollection)]
    public class SingleTaskRepositoryTest
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly ISingleTaskRepository _taskRepository;

        public SingleTaskRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _taskRepository = new SingleTaskRepository(_databaseFixture.TodoTasksContext);
        }

        [Fact]
        public async Task Should_returns_task_with_details()
        {
            var taskwithDetails = await _taskRepository.GetWithDetails(3);

            taskwithDetails.Should().NotBeNull();
            taskwithDetails.TaskName.Should().Be("przeczytanie książki \"ASP.NET Core\"");
            taskwithDetails.Details.Should().HaveCount(2);
        }

        [Fact]
        public async Task Should_returns_null_when_task_does_not_exist()
        {
            var taskwithDetails = await _taskRepository.GetWithDetails(9999);

            taskwithDetails.Should().BeNull();
        }

        [Fact]
        public async Task Should_returns_tasks_by_board_id()
        {
            var tasks = await _taskRepository.GetAll(1);

            tasks.Should().HaveCount(2);
        }

        [Fact]
        public async Task Should_returns_empty_list_of_tasks_when_do_not_exist_tasks_from_provided_board()
        {
            var tasks = await _taskRepository.GetAll(99999);

            tasks.Should().BeEmpty();
        }
    }
}
