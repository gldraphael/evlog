#!/bin/bash

# This script builds docker images for the application.
# NOTE: The script must be run from the project root directory.

docker run --name mongo-testdb \
    -p 27017:27017 \
    -d --rm mongo

docker build \
    -t gldraphael/evlog \
    --network host \
    -f ./src/Evlog.Web/Dockerfile .

docker build \
    -t gldraphael/evlog-self-contained \
    -f ./src/Evlog.Web/Dockerfile \
    --target self-contained .

docker stop mongo-testdb
