using AutoMapper;
using FluentAssertions;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.Queries;
using TodoListApp.Core.Domain;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.TasksTests
{
    public class TaskDetailsQueryHandlerTest : TestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public TaskDetailsQueryHandlerTest()
        {
            _mapper = CreateMapper();
            _fakeUnitOfWork = CreateUnitOfWorkMock();
        }

        [Fact]
        public async Task Should_returns_correct_mapped_taskInfoWithDetailsDto()
        {
            var tasksQueryHandler = new TaskDetailsQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.TasksMock.SetupTaskDetails();

            var result = await tasksQueryHandler.Handle(new TaskDetailsQuery
            {
                TaskId = 1
            }, CancellationToken.None);

            result.Should().NotBeNull();
            result.TaskName.Should().Be("bieganie");
            result.Details.Should().HaveCount(3);
            result.Details.First().TaskDetailName.Should().Be("dobiegnięcie do punktu A");
            result.Details.First().Description.Should().Be("opis...");
        }

        [Fact]
        public async Task Should_returns_null_when_task_does_not_exist()
        {
            var tasksQueryHandler = new TaskDetailsQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.TasksMock.Setup(x => x.GetWithDetails(It.IsAny<int>()))
                .Returns(Task.FromResult<SingleTask>(null));

            var result = await tasksQueryHandler.Handle(new TaskDetailsQuery
            {
                TaskId = 1
            }, CancellationToken.None);

            result.Should().BeNull();
        }
    }
}
