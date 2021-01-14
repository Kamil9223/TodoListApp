﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoListApp.Application.Exceptions;
using TodoListApp.Application.Users.Commands;
using TodoListApp.Application.Users.Services.Abstractions;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;
        private readonly IHttpContextAccessor _httpAccessor;

        public LoginService(IUnitOfWork unitOfWork, IEncrypter encrypter, IHttpContextAccessor httpAccessor)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
            _httpAccessor = httpAccessor;
        }

        public async Task LogIn(LoginUserCommand command)
        {
            var user = await _unitOfWork.Users.GetByEmail(command.Email);
            if (user == null)
                throw new InvalidCredentialsException();

            var hash = _encrypter.Encrypt(command.Password);
            if (user.PasswordHash != hash)
                throw new InvalidCredentialsException();

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, command.Email),
                new Claim("Id", user.UserId.ToString())
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(claimIdentity);

            await _httpAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = false
                });
        }

        public async Task LogOut()
        {
            await _httpAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
