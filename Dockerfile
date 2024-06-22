#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Stage 1: Base Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /home/app
EXPOSE 80

# Stage 2: Build Image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and project files for restoring dependencies
COPY ["Clinic.sln", "./"]
COPY ["Clinic/Clinic.csproj", "Clinic/"]
RUN dotnet restore "Clinic/Clinic.csproj"
# Copie des autres fichiers
COPY . .

# Copy the remaining files and build the project
WORKDIR /src/Clinic
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Stage 3: Publish Image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Clinic
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Final Image
FROM base AS final
WORKDIR /home/app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clinic.dll"]

ENTRYPOINT ["dotnet", "Clinic.dll"]