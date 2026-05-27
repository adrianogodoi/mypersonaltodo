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

/*
Caso deseja usar o SqLite descomencar essa linha e comentar a do SQl Server
builder.Services.AddDbContext<MyPersonalTodoDbContext>(options =>
    options.UseSqlite("Data Source=MyPersonalToDoDatabase.db", b =>
        b.MigrationsAssembly("MyPersonalToDo.Api")));
]*/

builder.Services.AddDbContext<MyPersonalTodoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("MyPersonalToDo.Api") 
    )
);



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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyPersonalTodoDbContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {

    }
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
    c.RoutePrefix = string.Empty; 
});

app.MapControllers();
app.Run();