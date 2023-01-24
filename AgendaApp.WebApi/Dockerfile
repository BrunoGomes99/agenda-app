#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AgendaApp.WebApi/AgendaApp.WebApi.csproj", "AgendaApp.WebApi/"]
COPY ["AgendaApp.Service/AgendaApp.Service.csproj", "AgendaApp.Service/"]
COPY ["AgendaApp.Domain/AgendaApp.Domain.csproj", "AgendaApp.Domain/"]
COPY ["AgendaApp.Repository/AgendaApp.Repository.csproj", "AgendaApp.Repository/"]
COPY ["AgendaApp.Test/AgendaApp.Test.csproj", "AgendaApp.Test/"]
RUN dotnet restore "AgendaApp.WebApi/AgendaApp.WebApi.csproj"
COPY . .
WORKDIR "/src/AgendaApp.WebApi"
RUN dotnet build "AgendaApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgendaApp.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendaApp.WebApi.dll"]