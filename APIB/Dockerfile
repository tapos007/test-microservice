FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIB/APIB.csproj", "APIB/"]
RUN dotnet restore "APIB/APIB.csproj"
COPY . .
WORKDIR "/src/APIB"
RUN dotnet build "APIB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIB.dll"]
