using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.Cookie.Name = "cookieAuth";
                });

            services.AddHttpContextAccessor();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IEncrypter, Encrypter>();

            return services;
        }
    }
}
