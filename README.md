# Evlog
> ⚡️A self-hosted platform for publishing events.

[![Travis (.org)](https://img.shields.io/travis/gldraphael/evlog.svg?style=popout-square)](https://travis-ci.org/gldraphael/evlog)


## Quickstart

You can try evlog right now if you have docker installed by running:

```bash
docker pull gldraphael/evlog-self-contained
docker run \
    -p 5200:80 \
    -it --rm gldraphael/evlog-self-contained
```

The app will be served at `localhost:5200`.

## Documentation Index

1. [Local dev environment setup](./docs/development)
1. [Application configuration](./docs/configuration)
