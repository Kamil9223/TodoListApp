﻿using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoTasksContext _todoTasksContext;

        public IUserRepository Users { get; }
        public ITasksBoardRepository Boards { get; }
        public ISingleTaskRepository Tasks { get; }

        public UnitOfWork(TodoTasksContext todoTasksContext,
            IUserRepository users,
            ITasksBoardRepository boards,
            ISingleTaskRepository tasks)
        {
            _todoTasksContext = todoTasksContext;
            Users = users;
            Boards = boards;
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
