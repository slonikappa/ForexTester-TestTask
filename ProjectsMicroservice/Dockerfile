#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /src
COPY ["ProjectsMicroservice/ProjectsMicroservice.csproj", "ProjectsMicroservice/"]
COPY ["ProjectsMicroservice.Application/ProjectsMicroservice.Application.csproj", "ProjectsMicroservice.Application/"]
COPY ["ProjectsMicroservice.Domain.Infrastructure/ProjectsMicroservice.Domain.Infrastructure.csproj", "ProjectsMicroservice.Domain.Infrastructure/"]
COPY ["ProjectMicroservices.Infrastructure.External/ProjectMicroservices.Infrastructure.External.csproj", "ProjectMicroservices.Infrastructure.External/"]
COPY ["ProjectsMicroservice.Domain.Core/ProjectsMicroservice.Domain.Core.csproj", "ProjectsMicroservice.Domain.Core/"]
COPY ["ProjectsMicroservice.Infrastructure.DataAccess/ProjectsMicroservice.Infrastructure.DataAccess.csproj", "ProjectsMicroservice.Infrastructure.DataAccess/"]
COPY ["ProjectsMicroservice.Inrastructure.BusinessLogic/ProjectsMicroservice.Inrastructure.BusinessLogic.csproj", "ProjectsMicroservice.Inrastructure.BusinessLogic/"]
RUN dotnet restore "ProjectsMicroservice/ProjectsMicroservice.csproj"
COPY . .
WORKDIR "/src/ProjectsMicroservice"
RUN dotnet build "ProjectsMicroservice.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectsMicroservice.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectsMicroservice.dll"]