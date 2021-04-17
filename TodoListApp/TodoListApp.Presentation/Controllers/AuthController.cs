using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Application.Users.Commands;
using TodoListApp.Application.Users.Queries;

namespace TodoListApp.Presentation.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(command);

            if (!IsCommandValid(result))
                return View();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(command);

            if(!IsCommandValid(result))
                return View();

            return RedirectToAction("Index", "Board");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _mediator.Send(new LogoutUserCommand());

            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Profile()
        {
            var profile = await _mediator.Send(new ProfileQuery
            {
                userId = Convert.ToInt32(
                    HttpContext.User.Claims.Where(x => x.Type == "Id").First().Value)
            });

            return View(profile);
        }
    }
}