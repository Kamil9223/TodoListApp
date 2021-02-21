using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface ITasksBoardRepository : IRepository<TasksBoard>
    {
        Task<IEnumerable<TasksBoard>> GetAllWithTasks(int userId);
    }
}
