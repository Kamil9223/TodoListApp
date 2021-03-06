﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.Commands;
using TodoListApp.Application.Tasks.Queries;

namespace TodoListApp.Presentation.Controllers
{
    [Authorize]
    public class TaskController : BaseController
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> AddTaskDetails(AddTaskDetailCommand command)
        {
            if (!ModelState.IsValid)
                return PartialView("AddTaskDetailPartial", command);

            var result = await _mediator.Send(command);

            if (!IsCommandValid(result))
                return PartialView("AddTaskDetailPartial", command);

            return new JsonResult("Redirect!");
        }

        public IActionResult AddTaskDetails(int taskId)
        {
            return PartialView("AddTaskDetailPartial", new AddTaskDetailCommand { TaskId = taskId });
        }

        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(TaskDetails));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDetail(RemoveTaskDetailCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(TaskDetails), new { id = command.TaskId });
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(AddTaskCommand command)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _mediator.Send(command);

            if (!IsCommandValid(result))
                return View();

            return RedirectToAction("Index", "Board", new { boardId = command.BoardId });
        }

        public IActionResult AddTask(int boardId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RemoveTaskCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction("Index", "Board", new { boardId = command.BoardId });
        }
    }
}