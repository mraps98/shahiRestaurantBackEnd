FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet tool restore
RUN dotnet ef database update
RUN dotnet publish -c Release -o out
RUN cat ./resetDatabase.sql | sqlite3 ./shahi.db

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal as base
WORKDIR /app
EXPOSE 80
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "shahiRestaurant.dll"]
