#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT Development
WORKDIR /src
COPY ["UserMicroservice/UserMicroservice.csproj", "UserMicroservice/"]
COPY ["UserMicroservice.Infrastructure.BusinessLogic/UserMicroservice.Infrastructure.BusinessLogic.csproj", "UserMicroservice.Infrastructure.BusinessLogic/"]
COPY ["UserMicroservice.Domain.Core/UserMicroservice.Domain.Infastructure.csproj", "UserMicroservice.Domain.Core/"]
COPY ["UserMicroservice.Domain/UserMicroservice.Domain.Core.csproj", "UserMicroservice.Domain/"]
COPY ["UserMicroservice.Application/UserMicroservice.Application.csproj", "UserMicroservice.Application/"]
COPY ["UserMicroservice.Infrastructure.DataAccess.DB/UserMicroservice.Infrastructure.DataAccess.DB.csproj", "UserMicroservice.Infrastructure.DataAccess.DB/"]
COPY ["UserMicroservice.Infrastructure.DataAccess/UserMicroservice.Infrastructure.DataAccess.csproj", "UserMicroservice.Infrastructure.DataAccess/"]
RUN dotnet restore "UserMicroservice/UserMicroservice.csproj"
COPY . .
WORKDIR "/src/UserMicroservice"
RUN dotnet build "UserMicroservice.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "UserMicroservice.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserMicroservice.dll"]