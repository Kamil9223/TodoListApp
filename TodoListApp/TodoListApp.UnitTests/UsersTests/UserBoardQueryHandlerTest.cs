using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Queries;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.UsersTests
{
    public class UserBoardQueryHandlerTest : UserTestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public UserBoardQueryHandlerTest()
        {
            _mapper = CreateMapper();

            var dbContext = new Mock<DbContext>();
            var userRepositoryMock = new Mock<IUserRepository>();
            _fakeUnitOfWork = CreateUnitOfWorkMock(dbContext.Object, userRepositoryMock);
        }

        [Fact]
        public async Task Should_returns_correct_mapped_main_panel_dto_when_user_has_at_least_one_board()
        {
            var userBoardQueryHandler = new UserBoardQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.UsersMock.SetupUserWithBoardsAndTasks();

            var result = await userBoardQueryHandler.Handle(new UserBoardQuery
            {
                userId = 1
            }, CancellationToken.None);

            result.Tasks.Should().HaveCount(3);
            result.Categories.Should().HaveCount(2);
        }

        [Fact]
        public async Task Should_returns_empty_dto_object_when_user_doesnt_has_boards()
        {
            var userBoardQueryHandler = new UserBoardQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.UsersMock.SetupUserWithoutAnyBoards();

            var result = await userBoardQueryHandler.Handle(new UserBoardQuery
            {
                userId = 1
            }, CancellationToken.None);

            result.Tasks.Should().BeEmpty();
            result.Categories.Should().BeEmpty();
        }
    }
}
