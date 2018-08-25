# Local dev environment setup

* [Software Requirements](#software-requirements)
* [MongoDB Setup](#mongodb-setup)
* [Build from source](#build-from-source)

## Software Requirements

**Requirements:** Docker, .NET Core SDK 2.1.400, yarn, parcel, VS Code, Visual Studio (Optional)   
**Recommended VS Code Extensions:** 
[C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp), 
[C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions), 
[.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer), 
[Docker](https://marketplace.visualstudio.com/items?itemName=PeterJausovec.vscode-docker), 
[GitLens](https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens)

## MongoDB Setup

### Pull the latest mongo image:

```bash
docker pull mongo
```

### Create a new container

(Adjust the local port and container name as needed.)

```bash
docker run --name mongo \
    -p 27017:27017 \
    -d mongo
```

The newly created `mongo` container should be running. You may verify it using `docker ps`. You may use `docker start mongo` start the container if it's not already running.

### Seed some data

Run the seed script from the project root using:

```bash
mongo localhost/admin ./scripts/seed.js
```

## Build from source

1. Clone the project and `cd` into the Web project's directory:
    ```bash
    git clone https://github.com/gldraphael/evlog.git
    cd evlog/src/Evlog.Web
    ```
1. Build front end assets:    
    ```
    yarn build
    ```

3. Run the application:
    ```
    dotnet run
    ```
