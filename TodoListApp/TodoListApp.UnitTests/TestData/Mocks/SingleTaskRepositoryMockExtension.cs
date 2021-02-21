using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public static class SingleTaskRepositoryMockExtension
    {
        public static Mock<ISingleTaskRepository> SetupTasksFromBoard(this Mock<ISingleTaskRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetTasksFromBoard(It.IsAny<int>()))
                .Returns(Task.FromResult(SingleTaskRepositoryTestData.CreateTasks()));

            return repositoryMock;
        }
    }
}
