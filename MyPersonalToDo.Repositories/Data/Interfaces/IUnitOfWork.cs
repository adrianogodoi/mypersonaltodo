using MyPersonalToDo.Domain.Models;

namespace MyPersonalToDo.Repositories.Data.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<ToDo> ToDos { get; }
        Task<int> CompleteAsync();
    }
}
