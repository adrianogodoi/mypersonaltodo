using MyPersonalToDo.Api.Responses;
using MyPersonalToDo.Domain.Filters;
using MyPersonalToDo.Domain.ViewModels;

namespace MyPersonalToDo.Api.Application.Interfaces
{
    public interface IToDoApplication
    {
        Task<ResponseMessage> GetAllAsync(FilterToDoViewModel? filter);
        Task<ResponseMessage> Add(ToDoViewModelAdd todoViewModel);
        Task<ResponseMessage> GetById(long id);
        Task<ResponseMessage> Update(ToDoViewModelUpdate todoViewModel);
        Task<ResponseMessage> Remove(long id);
    }
}
