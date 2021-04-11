using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoListApp.Core.DomainAccessAbstraction;
using TodoListApp.Persistance.Context;
using TodoListApp.Persistance.DataAccess;

namespace TodoListApp.Persistance.IoC
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoTasksContext>(x => 
                x.UseSqlServer(configuration.GetConnectionString("TodoTasksDb")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITasksBoardRepository, TasksBoardRepository>();
            services.AddScoped<ISingleTaskRepository, SingleTaskRepository>();
            services.AddScoped<ITaskDetailRepository, TaskDetailRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
