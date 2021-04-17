using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoListApp.Application.Boards.Commands;
using TodoListApp.Application.Boards.Queries;

namespace TodoListApp.Presentation.Controllers
{
    [Authorize]
    public class BoardController : BaseController
    {
        private readonly ILogger<BoardController> _logger;
        private readonly IMediator _mediator;

        public BoardController(ILogger<BoardController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int boardId)
        {
            var mainPanel = await _mediator.Send(new BoardQuery
            {
                UserId = Convert.ToInt32(
                    HttpContext.User.Claims.Where(x => x.Type == "Id").First().Value),
                BoardId = boardId
            });

            return View(mainPanel);
        }

        public IActionResult AddBoard()
        {
            return PartialView("AddBoardPartial");
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard(AddBoardCommand command)
        {
            if (!ModelState.IsValid)
                return PartialView("AddBoardPartial");

            command.userId = Convert.ToInt32(
                    HttpContext.User.Claims.Where(x => x.Type == "Id").First().Value);

            var result = await _mediator.Send(command);

            if (!IsCommandValid(result))
                return PartialView("AddBoardPartial");

            return new JsonResult("Redirect!");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBoard(RemoveBoardCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
