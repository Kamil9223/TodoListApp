﻿using System.Threading.Tasks;
using TodoListApp.Core.Domain;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetUserWithFirstBoard(int userId);
    }
}
