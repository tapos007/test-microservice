FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIA/APIA.csproj", "APIA/"]
RUN dotnet restore "APIA/APIA.csproj"
COPY . .
WORKDIR "/src/APIA"
RUN dotnet build "APIA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIA.dll"]
