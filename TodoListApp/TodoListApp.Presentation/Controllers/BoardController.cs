using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Application.Tasks.Queries;

namespace TodoListApp.Presentation.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IMediator _mediator;

        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Tasks(int taskBoardId)
        {
            var tasksCollection = await _mediator.Send(new TasksQuery
            {
                TasksBoardId = taskBoardId
            });

            return PartialView(nameof(Tasks), tasksCollection);
        }
    }
}