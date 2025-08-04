FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY ["Services/POIService/POIService.csproj", "Services/POIService/"]
COPY ["Common/SharedKernel/SharedKernel.csproj", "Common/SharedKernel/"]

RUN dotnet restore "Services/POIService/POIService.csproj"

COPY . .
WORKDIR "/src/Services/POIService"

RUN dotnet publish "POIService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "POIService.dll"]