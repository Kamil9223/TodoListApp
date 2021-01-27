﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TodoTasksContext todoTasksContext)
            : base(todoTasksContext)
        { }

        public async Task<User> GetByEmail(string email)
        {
            return await DbContext.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserWithBoards(int userId)
        {
            return await DbContext.Users
                .Include(x => x.Boards)
                    .ThenInclude(x => x.Tasks)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
