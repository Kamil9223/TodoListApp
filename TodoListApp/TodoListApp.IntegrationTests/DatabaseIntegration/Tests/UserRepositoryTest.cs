﻿using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration;
using TodoListApp.Persistance.DataAccess;
using Xunit;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.Tests
{
    [Collection(DatabaseFixture.DbCollection)]
    public class UserRepositoryTest
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly IUserRepository _userRepository;

        public UserRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _userRepository = new UserRepository(_databaseFixture.TodoTasksContext);
        }

        [Fact]
        public async Task Should_returns_user_by_email()
        {
            var user = await _userRepository.Get("testEmail");

            user.Should().NotBeNull();
            user.Email.Should().Be("testEmail");
        }

        [Fact]
        public async Task Should_returns_user_with_boards_and_tasks()
        {
            var userWithBoards = await _userRepository.GetWithBoardsAndTasks(1);

            userWithBoards.Should().NotBeNull();
            userWithBoards.Boards.Should().HaveCount(2);
            userWithBoards.Boards.First().Tasks.Should().HaveCount(2);
        }
    }
}
