using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public static class TasksBoardRepositoryMockExtension
    {
        public static Mock<ITasksBoardRepository> SetupTasksFromBoard(this Mock<ITasksBoardRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetTasksFromBoard(It.IsAny<int>()))
                .Returns(Task.FromResult(SingleTaskRepositoryTestData.CreateTasks()));

            return repositoryMock;
        }
    }
}
