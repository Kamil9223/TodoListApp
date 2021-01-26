using FluentAssertions;
using System;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;
using TodoListApp.Persistance.DataAccess;
using Xunit;

namespace TodoListApp.IntegrationTests.DatabaseIntegration.Tests
{
    public class UserRepositoryTest : TestBase, IDisposable
    {
        private readonly TodoTasksContext _todoTasksContext;
        private readonly IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            _todoTasksContext = CreateInMemoryDbContext();
            _userRepository = new UserRepository(_todoTasksContext);
        }

        public void Dispose()
        {
            //TODO: Rozwiązanie tymczasowe, docelowo nalezy utworzyć bazk inMemory
            //dla wszysktich testów inegracyjnych z bazą, dodać przykładowe dane, które
            //symulować będą konkretny stan. (AutoFixture)
            _todoTasksContext.Database.EnsureDeleted();
            _todoTasksContext.Dispose();
        }


        [Fact]
        public async Task Should_returns_user_by_email() //TODO: Refactoring
        {
            _todoTasksContext.Users.Add(new User("testEmail", "passwordHash"));
            await _todoTasksContext.SaveChangesAsync();

            var user = await _userRepository.GetByEmail("testEmail");

            user.Should().NotBeNull();
            user.Email.Should().Be("testEmail");
        }
    }
}
