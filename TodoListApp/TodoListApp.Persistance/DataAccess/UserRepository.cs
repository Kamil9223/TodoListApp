using Microsoft.EntityFrameworkCore;
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

        public async Task<User> Get(string email)
        {
            return await DbContext.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
