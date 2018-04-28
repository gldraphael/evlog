# Evlog

## Running the project

### Run using the image on DockerHub

```
docker pull gldraphael/evlog
docker run --rm -it -p 5200:80 gldraphael/evlog
```

The app will be served at `localhost:5200`.

### Build the image and run it

```
git clone https://github.com/gldraphael/evlog.git
cd evlog
docker-compose build
docker-compose up
```

The app will be served at `localhost:5200`.
