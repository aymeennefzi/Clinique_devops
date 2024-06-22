# Stage 1: Base Image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /home/app
EXPOSE 80

# Copy solution and project files for restoring dependencies
COPY ["Clinic.sln", "./"]
COPY ["Clinic/Clinic.csproj", "Clinic/"]
RUN dotnet restore "Clinic/Clinic.csproj"

# Copy the remaining files and build the project
COPY . .
WORKDIR /src/Clinic
RUN dotnet build -c Release -o /app/build

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
