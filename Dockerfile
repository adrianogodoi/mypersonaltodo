# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia os arquivos de solução e projetos
COPY *.slnx *.sln ./
COPY MyPersonalToDo.Api/*.csproj ./MyPersonalToDo.Api/
COPY MyPersonalToDo.Domain/*.csproj ./MyPersonalToDo.Domain/
COPY MyPersonalToDo.Repositories/*.csproj ./MyPersonalToDo.Repositories/
COPY MyPersonalToDo.Services/*.csproj ./MyPersonalToDo.Services/

# Restaura as dependências
RUN dotnet restore "MyPersonalToDoSolution.slnx"

# Copia o restante do código
COPY . .

# Publica a API
RUN dotnet publish "MyPersonalToDo.Api/MyPersonalToDo.Api.csproj" -c Release -o /publish

# Estágio 2: Runtime (O que faltava para a API rodar)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

# Garante que a aplicação escute na porta 80 do container
ENV ASPNETCORE_URLS=http://+:80

# Comando que mantém o container rodando
ENTRYPOINT ["dotnet", "MyPersonalToDo.Api.dll"]