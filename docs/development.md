# Local dev environment setup

* [Software Requirements](#software-requirements)
* [MySql Setup](#mysql-setup)
* [Build from source](#build-from-source)

## Software Requirements

**Requirements:** Docker, .NET Core SDK 2.1.400, yarn, parcel, VS Code / Visual Studio / Rider   
**Recommended VS Code Extensions:** 
[C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp), 
[C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions), 
[.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer), 
[Docker](https://marketplace.visualstudio.com/items?itemName=PeterJausovec.vscode-docker), 
[GitLens](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)

## MySql Setup

### Create a new container

(Adjust the local port and container name as needed.)

```bash
docker run \
    -p 3307:3306 \
    --name evlogdbserver \
    -e MYSQL_ROOT_PASSWORD=Pa5sw0rd \
    -d mysql:8.0.21
```

The newly created `evlogdbserver` container should be running. You may verify it using `docker ps`.

### Seed some data

TODO: fill this up

## Build from source

1. Clone the project and `cd` into the Web project's directory:
    ```bash
    git clone https://github.com/gldraphael/evlog.git
    cd evlog/src/Evlog.Web
    ```
1. Build front end assets:    
    ```bash
    yarn build
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

## EF Migrations

* Migration commands must be run from the `./src/Evlog.Infrastructure` directory.
* To create a new migration:
    ```bash
    dotnet ef migrations add InitCreate -s ../Evlog.Web/Evlog.Web.csproj
    ```
* Migrations are applied automatically application startup. You may do it manuall using:
    ```bash
    dotnet ef database update -s ../Evlog.Web/Evlog.Web.csproj
    ```
    