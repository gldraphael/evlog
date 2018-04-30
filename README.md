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
2. Run parcel.    
   _(Use `parcel watch` during development.)_
```
parcel build assets/bundle.js --out-dir wwwroot/dist/
```

3. Run the application:
```
cd /path/to/evlog/src/Evlog.Web
dotnet run
```
