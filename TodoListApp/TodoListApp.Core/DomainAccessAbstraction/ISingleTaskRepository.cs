using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface ISingleTaskRepository : IRepository<SingleTask>
    {
        Task<SingleTask> GetWithDetails(int taskId);
        Task<IEnumerable<SingleTask>> GetAll(int boardId);
    }
}
