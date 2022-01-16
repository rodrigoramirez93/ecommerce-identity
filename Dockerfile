# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build-env
WORKDIR /app

COPY ./ ./
RUN dotnet restore ./ecommerce-identity/IdentityServer.sln

RUN ls
RUN dotnet publish ./ecommerce-identity/IdentityServer.sln -c Release -o ./out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
RUN ls
ENTRYPOINT ["dotnet", "IdentityServer.API.dll"]
