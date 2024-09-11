# Imagem base para build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY ["LSF.csproj", "./"]
RUN dotnet restore "LSF.csproj"

# Copia o restante dos arquivos e compila a aplicação
COPY . .
RUN dotnet build "LSF.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "LSF.csproj" -c Release -o /app/publish

# Imagem base para execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=publish /app/publish .

# Expõe a porta que a aplicação escuta
EXPOSE 80
EXPOSE 443
EXPOSE 8080

# Define o ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "LSF.dll"]
