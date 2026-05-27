using MyPersonalToDo.Domain.Models;
using System.Linq.Expressions;

namespace MyPersonalToDo.Services.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDo>> GetAllAsync(Expression<Func<ToDo, bool>> predicate);
        Task<ToDo?> Add(ToDo todo);
        Task<ToDo?> GetById(long id);
        Task<ToDo> Update(ToDo todo);
        Task<bool> Remove(long id);
    }
}
