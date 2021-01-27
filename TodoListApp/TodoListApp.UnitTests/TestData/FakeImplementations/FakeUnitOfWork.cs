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

        public Mock<IUserRepository> UsersMock { get; set; }

        public FakeUnitOfWork(DbContext dbContext, Mock<IUserRepository> usersMock)
        {
            _dbContext = dbContext;
            UsersMock = usersMock;
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
