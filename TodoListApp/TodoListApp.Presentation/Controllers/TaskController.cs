using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.Commands;
using TodoListApp.Application.Tasks.Queries;

namespace TodoListApp.Presentation.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
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

        public async Task<IActionResult> TaskDetails(int id)
        {
            var taskInfo = await _mediator.Send(new TaskDetailsQuery
            {
                TaskId = id
            });

            return View(taskInfo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            await _mediator.Send(command);

            return RedirectToAction("Index", "Board");
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}