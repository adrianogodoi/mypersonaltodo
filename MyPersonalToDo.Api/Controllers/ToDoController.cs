using Microsoft.AspNetCore.Mvc;
using MyPersonalToDo.Api.Application.Interfaces;
using MyPersonalToDo.Domain.ViewModels;
using MyPersonalToDo.Api.Extensions;
using MyPersonalToDo.Domain.Filters;

namespace MyPersonalToDo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly IToDoApplication _todoApplication;
        public ToDoController(IToDoApplication todoApplication) {
            _todoApplication = todoApplication;
        }

        [HttpPost("List")]
        public async Task<IActionResult> List(FilterToDoViewModel? filter)
        {
            return this.ResponseResult(await _todoApplication.GetAllAsync(filter));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ToDoViewModelAdd todoViewModel)
        {
            return this.ResponseResult(await _todoApplication.Add(todoViewModel));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return this.ResponseResult(await _todoApplication.GetById(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ToDoViewModelUpdate todoViewModel)
        {
            return this.ResponseResult(await _todoApplication.Update(todoViewModel));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return this.ResponseResult(await _todoApplication.Remove(id));
        }

    }
}
