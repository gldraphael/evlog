# Evlog
> ⚡️A self-hosted platform for publishing events.

[![Travis (.org)](https://img.shields.io/travis/gldraphael/evlog/master.svg?style=popout-square&logo=travis&logoWidth=12)](https://travis-ci.org/gldraphael/evlog)
[![Build](https://img.shields.io/appveyor/ci/Galdin/evlog/master.svg?logo=appveyor&logoWidth=12&style=popout-square)](https://ci.appveyor.com/project/Galdin/evlog/branch/master)
[![Tests](https://img.shields.io/appveyor/tests/Galdin/evlog/master.svg?style=popout-square&logo=appveyor&logoWidth=12)](https://ci.appveyor.com/project/Galdin/evlog/branch/master/tests)

## Quickstart

1. Install Docker (Docker for Mac/Windows or Docker Toolbox or Docker CE).
1. Run the container:

    ```bash
    docker pull gldraphael/evlog-self-contained
    docker run \
        -p 5200:80 \
        -it --rm gldraphael/evlog-self-contained
    ```

The app will be served at `localhost:5200`.

## Documentation Index

1. [Local dev environment setup](./docs/development.md)
1. [Application configuration](./docs/configuration.md)
