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
        public ISingleTaskRepository Tasks { get => TasksMock.Object; }

        public Mock<IUserRepository> UsersMock { get; set; }
        public Mock<ISingleTaskRepository> TasksMock { get; set; }

        public FakeUnitOfWork(DbContext dbContext,
            Mock<IUserRepository> usersMock,
            Mock<ISingleTaskRepository> tasksMock)
        {
            _dbContext = dbContext;
            UsersMock = usersMock;
            TasksMock = tasksMock;
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
