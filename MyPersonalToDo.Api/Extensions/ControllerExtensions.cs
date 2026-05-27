using Microsoft.AspNetCore.Mvc;
using MyPersonalToDo.Api.Responses;

namespace MyPersonalToDo.Api.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseResult(this ControllerBase controller, ResponseMessage response)
        {
            return controller.Ok(response);
        }
    }
}
