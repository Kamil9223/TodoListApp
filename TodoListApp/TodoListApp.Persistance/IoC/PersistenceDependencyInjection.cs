using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoListApp.Persistance.Context;

namespace TodoListApp.Persistance.IoC
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoTasksContext>(x => 
                x.UseSqlServer(configuration.GetConnectionString("TodoTasksDb")));

            return services;
        }
    }
}
