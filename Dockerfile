FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tanner.EmailApi/Tanner.EmailApi.csproj", "Tanner.EmailApi/"]
RUN dotnet restore "Tanner.EmailApi/Tanner.EmailApi.csproj"
COPY . .
WORKDIR "/src/Tanner.EmailApi"
RUN dotnet build "Tanner.EmailApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tanner.EmailApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tanner.EmailApi.dll"]