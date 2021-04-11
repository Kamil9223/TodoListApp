using System;
using System.Threading.Tasks;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITasksBoardRepository Boards { get; }
        ISingleTaskRepository Tasks { get; }
        ITaskDetailRepository TaskDetails { get; }
        Task<int> Complete();
    }
}
