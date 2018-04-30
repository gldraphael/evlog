#
# Stage 0
# Base
FROM microsoft/aspnetcore:2.0.6 AS base
WORKDIR /app
EXPOSE 80

#
# Stage 1
# Build
FROM microsoft/aspnetcore-build:2.0.5-2.1.4 AS build

# Install yarn
RUN apt-get -qq update && apt-get --assume-yes install apt-transport-https
RUN curl -sS https://dl.yarnpkg.com/debian/pubkey.gpg | apt-key add -
RUN echo "deb https://dl.yarnpkg.com/debian/ stable main" | tee /etc/apt/sources.list.d/yarn.list
RUN apt-get -qq update && apt-get --assume-yes install yarn
RUN yarn global add parcel-bundler

# Copy the project files over & restore dependencies
WORKDIR /src
COPY evlog.sln ./
COPY src/Evlog.Web/Evlog.Web.csproj src/Evlog.Web/
COPY src/Evlog.Domain/Evlog.Domain.csproj src/Evlog.Domain/
COPY src/Evlog.Services/Evlog.Services.csproj src/Evlog.Services/
COPY tests/Evlog.UnitTests/Evlog.UnitTests.csproj src/Evlog.UnitTests/
RUN dotnet restore -nowarn:msb3202,nu1503

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
RUN parcel build assets/bundle.js --out-dir wwwroot/dist/
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
