using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public static class UserRepositoryMockExtensions
    {
        public static Mock<IUserRepository> SetupUser(this Mock<IUserRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(UserRepositoryMock.CreateUser()));

            return repositoryMock;
        }

        public static Mock<IUserRepository> SetupUserWithFirstBoard(this Mock<IUserRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetUserWithFirstBoard(It.IsAny<int>()))
                .Returns(Task.FromResult(UserRepositoryMock.CreateUserWithFirstBoard()));

            return repositoryMock;
        }

        public static Mock<IUserRepository> SetupUserWithoutAnyBoards(this Mock<IUserRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetUserWithFirstBoard(It.IsAny<int>()))
                .Returns(Task.FromResult(UserRepositoryMock.CreateUser()));

            return repositoryMock;
        }
    }
}
