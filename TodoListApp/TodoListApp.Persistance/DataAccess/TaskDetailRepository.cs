using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class TaskDetailRepository : Repository<TaskDetails>, ITaskDetailRepository
    {
        public TaskDetailRepository(TodoTasksContext todoTasksContext)
            : base(todoTasksContext)
        {

        }
    }
}
