using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Boards.Queries;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.BoardsTests
{
    public class TasksQueryHandlerTest : BoardTestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public TasksQueryHandlerTest()
        {
            _mapper = CreateMapper();

            var dbContext = new Mock<DbContext>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var tasksBoardRepositoryMock = new Mock<ITasksBoardRepository>();
            var tasksRepositoryMock = new Mock<ISingleTaskRepository>();
            _fakeUnitOfWork = CreateUnitOfWorkMock(dbContext.Object, userRepositoryMock, tasksBoardRepositoryMock, tasksRepositoryMock);
        }

        [Fact]
        public async Task Should_returns_correct_mapped_list_of_mainPanelTasksDto()
        {
            var tasksQueryHandler = new TasksQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.BoardsMock.SetupTasksFromBoard();

            var result = await tasksQueryHandler.Handle(new TasksQuery
            {
                TasksBoardId = 1
            }, CancellationToken.None);

            result.Count.Should().Be(3);
            result.First().TaskName.Should().Be("sprzątanie pokoju");
        }
    }
}
