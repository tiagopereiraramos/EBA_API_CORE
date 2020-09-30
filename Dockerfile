#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EBA_API_CORE.csproj", ""]
RUN dotnet restore "./EBA_API_CORE.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "EBA_API_CORE.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EBA_API_CORE.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EBA_API_CORE.dll"]