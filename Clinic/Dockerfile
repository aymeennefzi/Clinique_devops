# Définition de l'image de base pour le build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copie du fichier csproj et restauration des dépendances
COPY ["Clinic/Clinic.csproj", "Clinic/"]
RUN dotnet restore "Clinic/Clinic.csproj"

# Copie du code source et build de l'application
COPY . .
WORKDIR "/app/Clinic"
RUN dotnet build "Clinic.csproj" -c Release -o /app/build

# Définition de l'image de base pour l'exécution
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80

# Copie des fichiers de build depuis le conteneur de build
COPY --from=build /app/build .

# Commande d'entrée de l'application
ENTRYPOINT ["dotnet", "Clinic.dll"]
