using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface ISingleTaskRepository : IRepository<SingleTask>
    {
        Task<IEnumerable<SingleTask>> GetTasksFromBoard(int boardId);
        Task<SingleTask> GetTaskWithDetails(int taskId);
    }
}
