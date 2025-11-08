# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Microservices/Inventory/Inventory.API/Inventory.API.csproj", "Microservices/Inventory/Inventory.API/"]
COPY ["Common/Common.RestApi/Common.RestApi.csproj", "Common/Common.RestApi/"]
COPY ["Common/Common.Audit/Common.Audit.csproj", "Common/Common.Audit/"]
COPY ["Common/Common.CoreEntity/Common.CoreEntity.csproj", "Common/Common.CoreEntity/"]
COPY ["Common/Common.EventBus/Common.EventBus.csproj", "Common/Common.EventBus/"]
RUN dotnet restore "./Microservices/Inventory/Inventory.API/Inventory.API.csproj"
COPY . .
WORKDIR "/src/Microservices/Inventory/Inventory.API"
RUN dotnet build "./Inventory.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Inventory.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.API.dll"]