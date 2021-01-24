using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.UnitTests.TestData.FakeImplementations
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IUserRepository Users { get; }

        public FakeUnitOfWork(DbContext dbContext, IUserRepository users)
        {
            _dbContext = dbContext;
            Users = users;
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
