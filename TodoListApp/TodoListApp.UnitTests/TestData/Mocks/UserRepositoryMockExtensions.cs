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
                .Returns(Task.FromResult(UserRepositoryTestData.CreateUser()));

            return repositoryMock;
        }
    }
}
