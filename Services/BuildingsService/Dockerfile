FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["Services/BuildingsService/BuildingsService.csproj", "Services/BuildingsService/"]
COPY ["Common/SharedKernel/SharedKernel.csproj", "Common/SharedKernel/"]

RUN dotnet restore "Services/BuildingsService/BuildingsService.csproj"

COPY . .
WORKDIR "/src/Services/BuildingsService"

RUN dotnet build "BuildingsService.csproj" -c Release -o /app/build

RUN dotnet publish "BuildingsService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "BuildingsService.dll"]