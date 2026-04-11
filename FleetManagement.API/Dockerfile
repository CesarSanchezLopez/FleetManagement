# =========================
# Base runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Render usa el puerto 10000
ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

# =========================
# Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["FleetManagement.API/FleetManagement.API.csproj", "FleetManagement.API/"]
COPY ["FleetManagement.Application/FleetManagement.Application.csproj", "FleetManagement.Application/"]
COPY ["FleetManagement.Domain/FleetManagement.Domain.csproj", "FleetManagement.Domain/"]
COPY ["FleetManagement.Persistence/FleetManagement.Persistence.csproj", "FleetManagement.Persistence/"]

RUN dotnet restore "FleetManagement.API/FleetManagement.API.csproj"

COPY . .
WORKDIR "/src/FleetManagement.API"

RUN dotnet build "FleetManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# =========================
# Publish
# =========================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "FleetManagement.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# =========================
# Final image
# =========================
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "FleetManagement.API.dll"]