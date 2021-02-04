using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoTasksContext _todoTasksContext;

        public IUserRepository Users { get; }
        public ISingleTaskRepository Tasks { get; }

        public UnitOfWork(TodoTasksContext todoTasksContext, IUserRepository users, 
            ISingleTaskRepository tasks)
        {
            _todoTasksContext = todoTasksContext;
            Users = users;
            Tasks = tasks;
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
