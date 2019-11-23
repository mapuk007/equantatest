FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Equanta.Book/Equanta.Book.csproj", "Equanta.Book/"]
RUN dotnet restore "Equanta.Book/Equanta.Book.csproj"
COPY . .
WORKDIR "/src/Equanta.Book"
RUN dotnet build "Equanta.Book.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Equanta.Book.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Equanta.Book.dll"]