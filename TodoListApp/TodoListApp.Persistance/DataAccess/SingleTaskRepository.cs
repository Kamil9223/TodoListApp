using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class SingleTaskRepository : Repository<SingleTask>, ISingleTaskRepository
    {
        public SingleTaskRepository(TodoTasksContext todoTasksContext)
            : base(todoTasksContext)
        {

        }

        public async Task<SingleTask> GetWithDetails(int taskId)
        {
            return await DbContext.Tasks
                .Include(x => x.Details)
                .SingleOrDefaultAsync(x => x.SingleTaskId == taskId);
        }

        public async Task<IEnumerable<SingleTask>> GetAll(int boardId)
        {
            return await DbContext.Tasks
               .Where(x => x.Board.TasksBoardId == boardId)
               .ToListAsync();
        }
    }
}
