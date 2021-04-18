using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
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

        public static Mock<ISingleTaskRepository> SetupTaskDetails(this Mock<ISingleTaskRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetWithDetails(It.IsAny<int>()))
                .Returns(Task.FromResult(TaskRepositoryTestData.CreateTaskWithDetails()));

            return repositoryMock;
        }

        public static Mock<ISingleTaskRepository> SetupEmptyTasksList(this Mock<ISingleTaskRepository> repositoryMock)
        {
            repositoryMock.Setup(x => x.GetAll(It.IsAny<int>()))
                .Returns(Task.FromResult(new List<SingleTask>().AsEnumerable()));

            return repositoryMock;
        }
    }
}
