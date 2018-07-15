FROM microsoft/aspnetcore:2.0 AS base
MAINTAINER vadalexan@gmail.com
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY Training.Docker.WebApp/Training.Docker.WebApp.csproj Training.Docker.WebApp/
RUN dotnet restore
COPY . .
WORKDIR /src/Training.Docker.WebApp
RUN dotnet bundle
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Training.Docker.WebApp.dll"]