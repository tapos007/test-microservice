FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIAuthServer/APIAuthServer.csproj", "APIAuthServer/"]
RUN dotnet restore "APIAuthServer/APIAuthServer.csproj"
COPY . .
WORKDIR "/src/APIAuthServer"
RUN dotnet build "APIAuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIAuthServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIAuthServer.dll"]
