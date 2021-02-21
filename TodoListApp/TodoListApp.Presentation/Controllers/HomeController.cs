using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Application.Boards.Queries;

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
            var mainPanel = await _mediator.Send(new BoardQuery
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
    }
}
