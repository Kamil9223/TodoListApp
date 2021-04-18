using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
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
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TasksBoardRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _boardRepository = new TasksBoardRepository(_databaseFixture.TodoTasksContext);
            _userRepository = new UserRepository(_databaseFixture.TodoTasksContext);

            _unitOfWork = new UnitOfWork(
                _databaseFixture.TodoTasksContext,
                _userRepository,
                _boardRepository,
                null,
                null);
        }

        [Fact]
        public async Task Should_returns_boards_with_tasks()
        {
            var boards = await _boardRepository.GetAllWithTasks(1);

            boards.Should().NotBeNull();
            boards.Should().HaveCount(2);
            boards.First().Tasks.Should().HaveCount(2);
        }

        [Fact]
        public async Task Should_returns_empty_list_when_does_not_exist_any_board()
        {
            var boards = await _boardRepository.GetAllWithTasks(99999);

            boards.Should().BeEmpty();
        }

        [Fact]
        public async Task Should_add_board_to_existing_user()
        {
            var board = new TasksBoard("newCategory");

            var existingUser = await _unitOfWork.Users.Get(1);
            existingUser.Boards.Add(board);
            await _unitOfWork.Complete();

            board.TasksBoardId.Should().NotBe(default);
            board.User.Should().NotBeNull();

            _databaseFixture.Clear(board);
        }
    }
}
