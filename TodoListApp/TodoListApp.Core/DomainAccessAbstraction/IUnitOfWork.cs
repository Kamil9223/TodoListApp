using System;
using System.Threading.Tasks;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> Complete();
    }
}
