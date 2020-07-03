#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 5001
ENV ASPNETCORE_URLS=http://+:5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["OpenUITwitchBot/OpenUITwitchBot.csproj", "OpenUITwitchBot/"]
COPY ["Factories/Factories.csproj", "Factories/"]
COPY ["Models/Models.csproj", "Models/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Repositories/Repositories.csproj", "Repositories/"]
RUN dotnet restore "OpenUITwitchBot/OpenUITwitchBot.csproj"
COPY . .
WORKDIR "/src/OpenUITwitchBot"
RUN dotnet build "OpenUITwitchBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenUITwitchBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenUITwitchBot.dll"]