﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        public async Task<IActionResult> TaskDetails(int id)
        {
            var taskInfo = await _mediator.Send(new TaskDetailsQuery
            {
                TaskId = id
            });

            return View(taskInfo);
        }
    }
}