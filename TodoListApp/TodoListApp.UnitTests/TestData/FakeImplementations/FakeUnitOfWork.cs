using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.FakeImplementations
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IUserRepository Users { get => UsersMock.Object; }
        public ITasksBoardRepository Boards { get => BoardsMock.Object; }
        public ISingleTaskRepository Tasks { get => TasksMock.Object; }
        public ITaskDetailRepository TaskDetails { get => DetailsMock.Object; }

        public Mock<IUserRepository> UsersMock { get; set; }
        public Mock<ITasksBoardRepository> BoardsMock { get; set; }
        public Mock<ISingleTaskRepository> TasksMock { get; set; }
        public Mock<ITaskDetailRepository> DetailsMock { get; set; }

        public FakeUnitOfWork(DbContext dbContext,
            Mock<IUserRepository> usersMock,
            Mock<ITasksBoardRepository> boardsMock,
            Mock<ISingleTaskRepository> tasksMock,
            Mock<ITaskDetailRepository> detailsMock)
        {
            _dbContext = dbContext;
            UsersMock = usersMock;
            BoardsMock = boardsMock;
            TasksMock = tasksMock;
            DetailsMock = detailsMock;
        }

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
