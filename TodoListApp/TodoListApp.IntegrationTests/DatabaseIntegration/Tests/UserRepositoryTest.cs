using FluentAssertions;
using System;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.IntegrationTests.DatabaseIntegration.DatabaseConfiguration;
using TodoListApp.Persistance.Context;
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
        public async Task Should_returns_user_by_email() //TODO: Refactoring
        {
            var user = await _userRepository.GetByEmail("testEmail");

            user.Should().NotBeNull();
            user.Email.Should().Be("testEmail");
        }
    }
}
