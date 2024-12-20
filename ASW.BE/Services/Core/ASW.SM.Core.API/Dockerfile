#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 20001

ARG BUILD_CONFIGURATION=DockerDev

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Core/ASW.SM.Core.API/ASW.SM.Core.API.csproj", "Services/Core/ASW.SM.Core.API/"]
RUN dotnet restore "./Services/Core/ASW.SM.Core.API/ASW.SM.Core.API.csproj"
COPY . .
WORKDIR "/src/Services/Core/ASW.SM.Core.API"
RUN dotnet build "./ASW.SM.Core.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
RUN dotnet publish "./ASW.SM.Core.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# final images    
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:20001
ENV ASPNETCORE_ENVIRONMENT=$BUILD_CONFIGURATION
EXPOSE 20001
ENTRYPOINT ["dotnet", "ASW.SM.Core.API.dll"]