using System.Linq.Expressions;

namespace MyPersonalToDo.Repositories.Data.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(long id);
        void Update(T entity);
        void Remove(T entity);
    }
}
