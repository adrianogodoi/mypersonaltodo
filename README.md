
## My Personal ToDo

### Introdução

O MyPersonalTodo e uma API para gerenciamento de tarefas.

### Executar imagem a partir do Docker Hub

Instale o Docker Desktop

Crie uma rede  virtual
```bash
docker network create mypersonaltodo-net
```

Executar o container do servidor de banco de dados SQL Server
```bash
docker run -d --name sql_mypersonaltodo --network mypersonaltodo-net -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=MyPersonalToDo2026!" -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest
```

Executar o servidor da WebAPI
```bash
docker run -d --name mypersonaltodo_api --network mypersonaltodo-net  -p 8080:80 -e "ConnectionStrings__DefaultConnection=Server=sql_mypersonaltodo;Database=MyPersonalToDoDb;User Id=sa;Password=MyPersonalToDo2026!;TrustServerCertificate=True;"  godoiadriano/mypersonaltodo:latest
```

Acessando a aplicação

Para acessar a documentação Swagger da WebAPI use o seguinte endereço:

```bash
http://localhost:8080/index.html
```

### Executar imagem a partir do Docker Compose

Clone ou faça download do código  https://gitlab.com/adrianogodoi/mypersonaltodo.git

Instale o Docker Desktop em seu computador

Dentro do diretório raiz do projeto (Ex.: MyPersonalTodo) execute o comando:

```bash
docker-compose up --build -d
```
O Docker vai criar a rede e os dois containers, um com o SQL Server e o outro com a WebAPI

Para acessar a documentação use a url:

```bash
http://localhost:8080/index.html
```

### Importar Payloads no Postman

Para usar as chamadas dos endpoints use o arquivo MyPersonalToDo.postman_collection.json para importar dentro do POSTMAN 

### Banco de dados Local

Caso não disponha do Docker é possivel utilizar para fins de testes o banco de dados SQLite, apenas comente a linha que usa o SQL Server e descoment ao do SQLite

```CSharp
builder.Services.AddDbContext<MyPersonalTodoDbContext>(options =>
    options.UseSqlite("Data Source=MyPersonalToDoDatabase.db", b =>
        b.MigrationsAssembly("MyPersonalToDo.Api")));

/*
builder.Services.AddDbContext<MyPersonalTodoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("MyPersonalToDo.Api") 
    )
);*/
```