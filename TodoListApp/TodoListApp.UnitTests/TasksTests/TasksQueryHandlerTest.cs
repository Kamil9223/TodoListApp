using AutoMapper;
using FluentAssertions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.Queries;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.TasksTests
{
    public class TasksQueryHandlerTest : TestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public TasksQueryHandlerTest()
        {
            _mapper = CreateMapper();
            _fakeUnitOfWork = CreateUnitOfWorkMock();
        }

        [Fact]
        public async Task Should_returns_correct_mapped_list_of_tasksViewModel()
        {
            var tasksQueryHandler = new TasksQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.TasksMock.SetupTasks();

            var result = await tasksQueryHandler.Handle(new TasksQuery
            {
                TasksBoardId = 1
            }, CancellationToken.None);

            result.Tasks.Count.Should().Be(3);
            result.Tasks.First().TaskName.Should().Be("sprzątanie pokoju");
        }

        [Fact]
        public async Task Should_returns_tasksViewModel_with_empty_list_of_task_dtos()
        {
            var tasksQueryHandler = new TasksQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.TasksMock.SetupEmptyTasksList();

            var result = await tasksQueryHandler.Handle(new TasksQuery
            {
                TasksBoardId = 1
            }, CancellationToken.None);

            result.Tasks.Should().BeEmpty();
        }
    }
}
