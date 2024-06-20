FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8089

# Utilisation de l'image SDK pour la construction de l'application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copie et restauration du projet
COPY ["Clinic/Clinic.csproj", "Clinic/"]
RUN dotnet restore "./Clinic/Clinic.csproj"

# Copie de l'ensemble du code source et construction de l'application
COPY . .
WORKDIR "/src/Clinic"
RUN dotnet build "./Clinic.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publication de l'application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Clinic.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Étape finale pour l'exécution de l'application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Installation des outils Entity Framework Core
RUN dotnet tool install --global dotnet-ef

# Configuration du chemin d'accès pour les outils EF Core
ENV PATH="$PATH:/root/.dotnet/tools"

# Commande d'entrée pour lancer l'application avec la migration de base de données
ENTRYPOINT ["dotnet", "Clinic.dll", "--migrate"]
