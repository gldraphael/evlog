#
# Stage 0A
# Base
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS base
WORKDIR /app
EXPOSE 8080


#
# Stage 1
# Build front end assets
FROM node:lts-alpine AS frontend-build
RUN yarn global add parcel-bundler

WORKDIR /src
COPY src/Evlog.Web/package.json .
COPY src/Evlog.Web/yarn.lock .
RUN yarn

COPY ./src/Evlog.Web/assets/ ./assets/
RUN ls -r
RUN yarn build


#
# Stage 2
# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /src

COPY evlog.slnx Directory.Build.props  ./
COPY tests/Evlog.UnitTests/Evlog.UnitTests.csproj tests/Evlog.UnitTests/
COPY tests/Evlog.IntegrationTests/Evlog.IntegrationTests.csproj tests/Evlog.IntegrationTests/

COPY src/Evlog.Core/Evlog.Core.csproj src/Evlog.Core/
COPY src/Evlog.Infrastructure/Evlog.Infrastructure.csproj src/Evlog.Infrastructure/
COPY src/Evlog.Web/Evlog.Web.csproj src/Evlog.Web/

RUN dotnet restore evlog.slnx

WORKDIR /src
# TODO: Don't copy the front end assets
COPY . .

WORKDIR /src/src/Evlog.Web
RUN dotnet build -c Release -o /app


#
# Stage 3
# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /out


#
# Stage 4 Final
FROM base AS final
WORKDIR /app
COPY --from=publish /out .
RUN ls -r
ENTRYPOINT ["dotnet", "Evlog.Web.dll"]
