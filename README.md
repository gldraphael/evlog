# Evlog
> ⚡️A self-hosted platform for publishing events.

[![Travis (.org)](https://img.shields.io/travis/gldraphael/evlog/dev.svg?logo=travis&style=flat-square)](https://travis-ci.org/gldraphael/evlog)
![Azure DevOps tests](https://img.shields.io/azure-devops/tests/gldraphael/evlog/2/dev.svg?style=flat-square&logo=azure-pipelines)

> This is a work in progress. You can follow along by checking the issues on this repository, and the [public board](https://miro.com/app/board/o9J_knu59m8=/). And ofcourse, the source code too. If you have ideas or feature suggestions, please open a new issue.

<!-- ## Quickstart

1. Install Docker (Docker for Mac/Windows or Docker Toolbox or Docker CE).
1. Run the container:

    ```bash
    docker pull gldraphael/evlog
    docker run \
        -p 5200:80 \
        -it --rm gldraphael/evlog
    ```

The app will be served at `http://localhost:5200`. If you're using Docker Toolbox, replace `localhost` with the IP used by docker. -->

## Quickstart using docker-compose

```bash
docker-compose build
docker-compose up
```

The app will be served at `http://localhost:8080`.

Default credentials:

```
Username: admin@example.com
Password: theadmin'spassword
```

## Documentation Index

1. [Local dev environment setup](./docs/development.md)
1. [Application configuration](./docs/configuration.md)
