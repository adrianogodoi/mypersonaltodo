using Microsoft.EntityFrameworkCore;
using MyPersonalToDo.Domain.Models;

namespace MyPersonalToDo.Repositories.Data
{
    public class MyPersonalTodoDbContext : DbContext
    {
        public MyPersonalTodoDbContext(DbContextOptions<MyPersonalTodoDbContext> options): base(options) { }
        public DbSet<ToDo> ToDos => Set<ToDo>(); 
    }
}
