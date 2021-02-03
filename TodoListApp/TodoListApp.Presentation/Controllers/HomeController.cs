using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Application.Users.Queries;

namespace TodoListApp.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var mainPanel = await _mediator.Send(new UserBoardQuery
            {
                userId = Convert.ToInt32(
                    HttpContext.User.Claims.Where(x => x.Type == "Id").First().Value)
            });

            return View(mainPanel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tasks(int categoryId)
        {

            return PartialView(nameof(Tasks), categoryId);
        }
    }
}
