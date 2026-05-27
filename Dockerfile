# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia os arquivos .csproj de cada projeto para permitir a restauração
COPY ["MyPersonalToDo.Api/MyPersonalToDo.Api.csproj", "MyPersonalToDo.Api/"]
COPY ["MyPersonalToDo.Domain/MyPersonalToDo.Domain.csproj", "MyPersonalToDo.Domain/"]
COPY ["MyPersonalToDo.Repositories/MyPersonalToDo.Repositories.csproj", "MyPersonalToDo.Repositories/"]
COPY ["MyPersonalToDo.Services/MyPersonalToDo.Services.csproj", "MyPersonalToDo.Services/"]

# Restaura os pacotes NuGet apenas para a API (que referencia os outros)
RUN dotnet restore "MyPersonalToDo.Api/MyPersonalToDo.Api.csproj"

# Copia todo o restante do código fonte para dentro do container
COPY . .

# Compila e publica a API
RUN dotnet publish "MyPersonalToDo.Api/MyPersonalToDo.Api.csproj" -c Release -o /app/publish

# Estágio de Runtime (mais leve para rodar)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyPersonalToDo.Api.dll"]