using MyPersonalToDo.Domain.Models;
using MyPersonalToDo.Repositories.Data.Interfaces;
using MyPersonalToDo.Services.Interfaces;
using System.Linq.Expressions;

namespace MyPersonalToDo.Services
{

    public class ToDoService: IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync(Expression<Func<ToDo, bool>> predicate)
        {
            return await _unitOfWork.ToDos.GetAllAsync(predicate);
        }

        public async Task<ToDo?> Add(ToDo todo)
        {
            await _unitOfWork.ToDos.AddAsync(todo);
            await _unitOfWork.CompleteAsync();
            return todo;
        }

        public async Task<ToDo> Update(ToDo todo)
        {
            _unitOfWork.ToDos.Update(todo);
            await _unitOfWork.CompleteAsync();
            return todo;
        }

        public async Task<ToDo?> GetById(long id)
        {
            return await _unitOfWork.ToDos.GetByIdAsync(id);
        }

        public async Task<bool> Remove(long id)
        {
            var entidade = await _unitOfWork.ToDos.GetByIdAsync(id);
            if (entidade == null) return false;

            _unitOfWork.ToDos.Remove(entidade);
            return await _unitOfWork.CompleteAsync() > 0;
        }
    }
}
