using Microsoft.EntityFrameworkCore;
using MyPersonalToDo.Api.Application;
using MyPersonalToDo.Api.Application.Interfaces;
using MyPersonalToDo.Api.Mappings;
using MyPersonalToDo.Repositories.Data;
using MyPersonalToDo.Repositories.Data.Interfaces;
using MyPersonalToDo.Services;
using MyPersonalToDo.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<MyPersonalTodoDbContext>(options =>
    options.UseSqlite("Data Source=MyPersonalToDoDatabase.db", b =>
        b.MigrationsAssembly("MyPersonalToDo.Api")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IToDoApplication, ToDoApplication>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();