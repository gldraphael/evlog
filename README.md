# Evlog

### Quickstart

You can try evlog right now if you have docker installed by running:

```bash
docker pull gldraphael/evlog-self-contained
docker run -p 5200:80 -it --rm gldraphael/evlog-self-contained
```

The app will be served at `localhost:5200`.


### Build from source and run

**Prerequisites:** `.NET Core SDK 2.1.301`, `yarn`, `parcel`

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
