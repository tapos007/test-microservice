FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ProfileAPI/ProfileAPI.csproj", "ProfileAPI/"]
RUN dotnet restore "src/ProfileAPI/ProfileAPI.csproj"
COPY . .
WORKDIR "/src/ProfileAPI"
RUN dotnet build "ProfileAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProfileAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProfileAPI.dll"]
