# Evlog

## Running the project

### Run using the image on DockerHub

```bash
docker pull gldraphael/evlog
docker run --rm -it -p 5200:80 gldraphael/evlog
```

The app will be served at `localhost:5200`.

### Build the image and run it

```bash
git clone https://github.com/gldraphael/evlog.git
cd evlog
docker-compose build
docker-compose up
```

The app will be served at `localhost:5200`.

### Build from source and run

1. Clone the project and `cd` into the Web project's directory:
    ```bash
    git clone https://github.com/gldraphael/evlog.git
    cd evlog/src/Evlog.Web
    ```
1. Run `parcel build`:    
    ```
    yarn build
    ```
    During development, you may watch for changes to the front-end assets using `parcel watch` instead:
    ```
    yarn watch
    ```

3. Run the application:
    ```
    dotnet run
    ```
