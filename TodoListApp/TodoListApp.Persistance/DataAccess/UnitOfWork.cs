using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoTasksContext _todoTasksContext;

        public IUserRepository Users { get; }

        public UnitOfWork(TodoTasksContext todoTasksContext, IUserRepository users)
        {
            _todoTasksContext = todoTasksContext;
            Users = users;
        }

        public async Task<int> Complete()
        {
            return await _todoTasksContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _todoTasksContext.Dispose();
        }
    }
}
