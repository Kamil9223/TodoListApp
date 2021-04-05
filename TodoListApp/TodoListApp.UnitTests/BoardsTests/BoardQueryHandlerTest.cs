using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Boards.Queries;
using TodoListApp.UnitTests.TestData.FakeImplementations;
using TodoListApp.UnitTests.TestData.Mocks;
using Xunit;

namespace TodoListApp.UnitTests.BoardsTests
{
    public class BoardQueryHandlerTest : TestBase
    {
        private readonly IMapper _mapper;
        private readonly FakeUnitOfWork _fakeUnitOfWork;

        public BoardQueryHandlerTest()
        {
            _mapper = CreateMapper();
            _fakeUnitOfWork = CreateUnitOfWorkMock();
        }

        [Fact]
        public async Task Should_returns_correct_mapped_boardDto_when_user_has_at_least_one_board()
        {
            var userBoardQueryHandler = new BoardQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.BoardsMock.SetupBoardsWithTasks();

            var result = await userBoardQueryHandler.Handle(new BoardQuery
            {
                UserId = 1
            }, CancellationToken.None);

            result.Tasks.Should().HaveCount(3);
            result.Categories.Should().HaveCount(2);
            result.Categories.Should().Contain(new Dictionary<int, string>
            {
                { 1, "ogólne" },
                { 2, "programowanie" }
            });
        }

        [Fact]
        public async Task Should_returns_empty_dto_object_when_user_doesnt_has_boards()
        {
            var userBoardQueryHandler = new BoardQueryHandler(_fakeUnitOfWork, _mapper);

            _fakeUnitOfWork.BoardsMock.SetupEmptyBoardsList();

            var result = await userBoardQueryHandler.Handle(new BoardQuery
            {
                UserId = 1
            }, CancellationToken.None);

            result.Tasks.Should().BeEmpty();
            result.Categories.Should().BeEmpty();
        }
    }
}
