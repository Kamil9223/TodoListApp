using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Application.Users.Services.Implementations;

namespace TodoListApp.Application.IoC
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IRegisterService, RegisterService>();

            return services;
        }
    }
}
