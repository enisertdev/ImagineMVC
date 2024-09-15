# Temel imaj olarak .NET SDK kullanın
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Imagine/Imagine.csproj", "Imagine/"]
RUN dotnet restore "Imagine/Imagine.csproj"
COPY . .
WORKDIR "/src/Imagine"
RUN dotnet build "Imagine.csproj" -c Release -o /app/build

# Yayınlama aşaması
FROM build AS publish
RUN dotnet publish "Imagine.csproj" -c Release -o /app/publish

# Final aşama
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Imagine.dll"]
