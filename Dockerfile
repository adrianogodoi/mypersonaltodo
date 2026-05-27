# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 1. Copia apenas o arquivo de solução/projetos primeiro (para cachear os pacotes)
COPY *.slnx *.sln ./
COPY MyPersonalToDo.Api/*.csproj ./MyPersonalToDo.Api/

# 2. Restaura as dependências (agora o cache funciona melhor)
RUN dotnet restore "MyPersonalToDoSolution.slnx"

# 3. Copia o restante do código fonte
COPY . .

# 4. Publica
RUN dotnet publish "MyPersonalToDo.Api/MyPersonalToDo.Api.csproj" -c Release -o /publish

# Estágio de Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyPersonalToDo.Api.dll"]