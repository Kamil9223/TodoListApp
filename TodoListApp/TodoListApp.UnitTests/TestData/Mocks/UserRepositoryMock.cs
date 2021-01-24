using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public class UserRepositoryMock
    {
        public const string UserEmail = "test@email.com";

        public static Mock<IUserRepository> Create()
        {
            var mockRepository = new Mock<IUserRepository>();

            mockRepository.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(new User(UserEmail, "")));

            return mockRepository;
        }
    }
}
