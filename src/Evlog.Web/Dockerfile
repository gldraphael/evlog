#
# Stage 0
# Base
FROM microsoft/dotnet:2.1.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

#
# Stage 1
# Build
FROM microsoft/dotnet:2.1-sdk-alpine AS build

# Install yarn
RUN echo -e 'http://dl-cdn.alpinelinux.org/alpine/edge/main\nhttp://dl-cdn.alpinelinux.org/alpine/edge/community\nhttp://dl-cdn.alpinelinux.org/alpine/edge/testing' > /etc/apk/repositories
RUN apk add --no-cache yarn
RUN yarn global add parcel-bundler

# Copy the project files over & restore dependencies
WORKDIR /src

COPY evlog.sln ./
COPY docker-compose.dcproj .

COPY tests/Evlog.UnitTests/Evlog.UnitTests.csproj tests/Evlog.UnitTests/

COPY src/Evlog.Domain/Evlog.Domain.csproj src/Evlog.Domain/
COPY src/Evlog.Services/Evlog.Services.csproj src/Evlog.Services/
COPY src/Evlog.Web/Evlog.Web.csproj src/Evlog.Web/

# RUN dotnet sln evlog.sln remove docker-compose.dcproj
RUN dotnet restore evlog.sln

# Copy the package.json file & restore dependencies
WORKDIR /src/src/Evlog.Web
COPY src/Evlog.Web/package.json .
COPY src/Evlog.Web/yarn.lock .
RUN yarn

# Copy the remaining files over
WORKDIR /src
COPY . .

# Run tests
RUN dotnet test tests/tests.sln

# Build
WORKDIR /src/src/Evlog.Web
RUN yarn build
RUN dotnet build -c Release -o /app


#
# Stage 2
# Publish
FROM build AS publish
RUN dotnet publish -c Release -o /app

#
# Stage Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Evlog.Web.dll"]
