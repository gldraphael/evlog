#
# Stage 0A
# Base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview8-alpine3.9 AS base
WORKDIR /app
EXPOSE 80


#
# Stage 1
# Build
FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview8-alpine3.9 AS build

# Install yarn
RUN apk add --no-cache \
    yarn \
    mariadb \
    mariadb-client \
    openrc
RUN yarn global add parcel-bundler

# Copy the project files over & restore dependencies
WORKDIR /src

COPY evlog.sln ./
COPY docker-compose.dcproj .

COPY tests/Evlog.UnitTests/Evlog.UnitTests.csproj tests/Evlog.UnitTests/
COPY tests/Evlog.IntegrationTests/Evlog.IntegrationTests.csproj tests/Evlog.IntegrationTests/

COPY src/Evlog.Domain/Evlog.Domain.csproj src/Evlog.Domain/
COPY src/Evlog.Infrastructure/Evlog.Infrastructure.csproj src/Evlog.Infrastructure/
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
ENV ConnectionStrings__MySql=Server=localhost;Port=3306;Database=evlogitestdb;User=root;Pwd=mypassword;
RUN mysql_install_db --user=mysql --datadir=/var/db \
    && mysqld_safe --datadir='/var/db'  --console & \
    ps aux | grep mysql \
    && sleep 5 \
    && mysqladmin -u root password "mypassword" \
    && sleep 10 \
    && dotnet test tests/evlog-tests.sln

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
# Stage 0B
# Self contained base
FROM base As self-contained-base
RUN apk add --no-cache \
    mariadb \
    mariadb-client
RUN mysql_install_db --user=mysql --datadir=/var/db

#
# Stage 3B Final (self-contained)
# The self-contained container
FROM self-contained-base AS self-contained
WORKDIR /app
ENV ConnectionStrings__MySql=Server=localhost;Port=3306;Database=evlogitestdb;User=root;Pwd=mypassword;
COPY --from=publish /app .

# Setup the run script
RUN echo "#!/bin/sh" >> run.sh \
    && echo "mysqld_safe --datadir='/var/db'  --console &" >> run.sh \
    && echo "ps aux | grep mysql" >> run.sh \
    && echo "sleep 5" >> run.sh \
    && echo "mysqladmin -u root password \"mypassword\"" >> run.sh \
    && echo "sleep 10" >> run.sh \
    && echo "dotnet /app/Evlog.Web.dll" >> run.sh \
    && echo "mysql.server stop"  >> run.sh \
    && chmod +x run.sh

VOLUME /data/db
ENTRYPOINT ["./run.sh"]

#
# Stage 3 Final
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Evlog.Web.dll"]
