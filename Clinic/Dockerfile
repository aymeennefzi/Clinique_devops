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

# Copy the remaining files and build the project
COPY . .
WORKDIR /src/Clinic
RUN dotnet build "Clinic/Clinic.csproj" -c Release -o /app/build

# Stage 3: Publish Image
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Clinic
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage 4: Migration Image
FROM build AS migrations
RUN dotnet tool install --version 6.0.0 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /src
COPY . .
RUN dotnet ef migrations add first1 --project Clinic.csproj --startup-project Clinic.csproj

# Command to update the database
RUN dotnet ef database update --project Clinic.csproj --startup-project Clinic.csproj

# Stage 5: Final Image
FROM base AS final
WORKDIR /home/app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clinic.dll"]

ENTRYPOINT ["dotnet", "Clinic.dll"]