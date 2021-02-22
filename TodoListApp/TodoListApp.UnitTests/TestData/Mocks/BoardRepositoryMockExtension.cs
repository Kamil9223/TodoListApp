using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.Mocks
{
    public static class BoardRepositoryMockExtension
    {
        public static Mock<ITasksBoardRepository> SetupBoardsWithTasks(this Mock<ITasksBoardRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetAllWithTasks(It.IsAny<int>()))
                .Returns(Task.FromResult(BoardRepositoryTestData.CreateListOfBoardsWithTasks()));

            return repositoryMock;
        }

        public static Mock<ITasksBoardRepository> SetupEmptyBoardsList(this Mock<ITasksBoardRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetAllWithTasks(It.IsAny<int>()))
                .Returns(Task.FromResult(new List<TasksBoard>().AsEnumerable()));

            return repositoryMock;
        }
    }
}
