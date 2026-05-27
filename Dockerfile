# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia tudo de uma vez para o container. 
# Isso resolve erros de "arquivo não encontrado" ao tentar copiar subpastas manualmente.
COPY . .

# Restaura usando o arquivo de solução (se você tiver .sln ou .slnx, o dotnet restore encontra)
RUN dotnet restore

# Publica a API
RUN dotnet publish "MyPersonalToDo.Api/MyPersonalToDo.Api.csproj" -c Release -o /publish

# Estágio 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

# Define a porta
ENV ASPNETCORE_URLS=http://+:80

# Comando de entrada
ENTRYPOINT ["dotnet", "MyPersonalToDo.Api.dll"]