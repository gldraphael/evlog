# Evlog
> ⚡️A self-hosted platform for publishing events.

[![Travis (.org)](https://img.shields.io/travis/gldraphael/evlog/master.svg?style=popout-square&logo=travis&logoWidth=12)](https://travis-ci.org/gldraphael/evlog)
![Azure DevOps tests](https://img.shields.io/azure-devops/tests/gldraphael/evlog/2/master.svg?style=flat-square)

## Quickstart

1. Install Docker (Docker for Mac/Windows or Docker Toolbox or Docker CE).
1. Run the container:

    ```bash
    docker pull gldraphael/evlog-self-contained
    docker run \
        -p 5200:80 \
        -it --rm gldraphael/evlog-self-contained
    ```

The app will be served at `http://localhost:5200`. If you're using Docker Toolbox, replace `localhost` with the IP used by docker.

## Quickstart using docker-compose

```bash
docker-compose build
docker-compose up
```

The app will be served at `http://localhost:8080`.

## Documentation Index

1. [Local dev environment setup](./docs/development.md)
1. [Application configuration](./docs/configuration.md)
