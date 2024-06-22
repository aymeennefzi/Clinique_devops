##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["Clinic/Clinic.csproj", "Clinic/"]
#RUN dotnet restore "./Clinic/./Clinic.csproj"
#COPY . .
#WORKDIR "/src/Clinic"
#RUN dotnet build "./Clinic.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./Clinic.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Clinic.dll"]


# # Utiliser une image .NET SDK pour la construction de l'application
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# # Définir le répertoire de travail dans le conteneur
# WORKDIR /app

# # Copier les fichiers .csproj et restaurer les dépendances
# COPY *.csproj ./
# RUN dotnet restore ./Clinic.csproj

# # Copier tous les autres fichiers du projet dans le répertoire de travail
# COPY . .

# # Construire l'application
# RUN dotnet build ./Clinic.csproj -c Release -o /app/build

# # Publier l'application
# RUN dotnet publish ./Clinic.csproj -c Release -o /app/publish

# # Utiliser une image .NET Runtime pour exécuter l'application
# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/publish .

# # Exposer le port sur lequel l'application écoutera
# EXPOSE 80

# # Définir le point d'entrée de l'application
# ENTRYPOINT ["dotnet", "Clinic.dll"]

# Utiliser une image .NET SDK pour la construction de l'application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Définir le répertoire de travail dans le conteneur
WORKDIR /src

# Copier les fichiers .csproj et restaurer les dépendances
COPY Clinic/*.csproj ./Clinic/
RUN dotnet restore ./Clinic/Clinic.csproj

# Copier tous les autres fichiers du projet dans le répertoire de travail
COPY Clinic/. ./Clinic/

# Définir le répertoire de travail pour la construction
WORKDIR /src/Clinic

# Construire l'application
RUN dotnet build Clinic.csproj -c Release -o /app/build

# Publier l'application
RUN dotnet publish Clinic.csproj -c Release -o /app/publish

# Utiliser une image .NET Runtime pour exécuter l'application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exposer le port sur lequel l'application écoutera
EXPOSE 80

# Définir le point d'entrée de l'application
ENTRYPOINT ["dotnet", "Clinic.dll"]



