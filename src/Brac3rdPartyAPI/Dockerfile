FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Brac3rdPartyAPI/Brac3rdPartyAPI.csproj", "Brac3rdPartyAPI/"]
RUN dotnet restore "src/Brac3rdPartyAPI/Brac3rdPartyAPI.csproj"
COPY . .
WORKDIR "/src/Brac3rdPartyAPI"
RUN dotnet build "Brac3rdPartyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brac3rdPartyAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brac3rdPartyAPI.dll"]
