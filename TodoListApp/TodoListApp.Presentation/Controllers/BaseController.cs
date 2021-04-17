using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TodoListApp.Application.Common;

namespace TodoListApp.Presentation.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsCommandValid(ErrorResponse errorResponse)
        {
            if (!errorResponse.Errors.Any())
                return true;

            foreach(var error in errorResponse.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            return false;
        }
    }
}
