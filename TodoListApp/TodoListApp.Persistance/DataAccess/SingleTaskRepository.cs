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

        public async Task<IEnumerable<SingleTask>> GetTasksFromBoard(int boardId)
        {
            return await DbContext.Tasks
                .Where(x => x.Board.TasksBoardId == boardId)
                .ToListAsync();
        }
    }
}
