using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly TodoTasksContext DbContext;

        public Repository(TodoTasksContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T> Get(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public Task Add(T entity)
        {
            DbContext.Set<T>().Add(entity);

            return Task.CompletedTask;
        }

        public Task Remove(T entity)
        {
            DbContext.Set<T>().Remove(entity);

            return Task.CompletedTask;
        }
    }
}
