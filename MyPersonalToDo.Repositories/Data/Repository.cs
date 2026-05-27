using Microsoft.EntityFrameworkCore;
using MyPersonalToDo.Repositories.Data.Interfaces;
using System.Linq.Expressions;

namespace MyPersonalToDo.Repositories.Data
{
    public class Repository<T>: IRepository<T> where T : class
    {
        protected readonly MyPersonalTodoDbContext _context;

        public Repository(MyPersonalTodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
