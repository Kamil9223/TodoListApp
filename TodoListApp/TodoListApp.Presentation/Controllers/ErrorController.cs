using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlingPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionHandlingPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlingPathFeature.Error.Message;

            return View("Error");
        }
    }
}