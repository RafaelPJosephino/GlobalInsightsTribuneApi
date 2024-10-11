FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["GlobalInsightsTribune.MVC/GlobalInsightsTribune.MVC.csproj", "GlobalInsightsTribune.MVC/"]
RUN dotnet restore "GlobalInsightsTribune.MVC/GlobalInsightsTribune.MVC.csproj"

COPY . .
WORKDIR "/src/GlobalInsightsTribune.MVC"
RUN dotnet build "GlobalInsightsTribune.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GlobalInsightsTribune.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlobalInsightsTribune.MVC.dll"]