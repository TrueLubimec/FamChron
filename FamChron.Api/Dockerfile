#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FamChron.Api/FamChron.Api.csproj", "FamChron.Api/"]
COPY ["FamChron.Models/FamChron.Models.csproj", "FamChron.Models/"]
RUN dotnet restore "./FamChron.Api/./FamChron.Api.csproj"
COPY . .
WORKDIR "/src/FamChron.Api"
RUN dotnet build "./FamChron.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FamChron.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamChron.Api.dll"]

#можно оптимизировать (стр.81 учебника майков)