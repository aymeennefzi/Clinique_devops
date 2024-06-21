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
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Clinic/Clinic.csproj"
RUN dotnet build "Clinic/Clinic.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Clinic/Clinic.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Clinic ./Clinic
ENTRYPOINT ["dotnet", "Clinic.dll"]