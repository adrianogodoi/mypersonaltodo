using MyPersonalToDo.Domain.Models;
using MyPersonalToDo.Repositories.Data.Interfaces;

namespace MyPersonalToDo.Repositories.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MyPersonalTodoDbContext _context;

        public UnitOfWork(MyPersonalTodoDbContext context)
        {
            _context = context;
        }

        public IRepository<ToDo> ToDos => new Repository<ToDo>(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
