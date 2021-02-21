using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class TasksBoardRepository : Repository<TasksBoard>, ITasksBoardRepository
    {
        public TasksBoardRepository(TodoTasksContext todoTasksContext)
            : base(todoTasksContext)
        {

        }

        public async Task<IEnumerable<TasksBoard>> GetAllWithTasks(int userId)
        {
            return await DbContext.Boards
                .Include(x => x.Tasks)
                .Where(x => x.User.UserId == userId)
                .ToListAsync();
        }
    }
}
