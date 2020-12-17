using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;

namespace TodoListApp.Core.DomainAccessAbstraction
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserWithBoards(int userId);
    }
}
