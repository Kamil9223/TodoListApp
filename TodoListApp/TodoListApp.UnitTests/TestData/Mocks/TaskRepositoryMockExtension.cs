using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public static class TaskRepositoryMockExtension
    {
        public static Mock<ISingleTaskRepository> SetupTasks(this Mock<ISingleTaskRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetAll(It.IsAny<int>()))
                .Returns(Task.FromResult(TaskRepositoryTestData.CreateTasks()));

            return repositoryMock;
        }
    }
}
