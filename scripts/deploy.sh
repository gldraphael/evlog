#!/bin/bash

# This script pushes the local image to dockerhub.
# You must be a collaborator for this to work for you.
# If you're running it locally, make sure you're logged in with the correct dockerhub account first.
# If you're invoking this on CI, set the following environment variables:
#   1. $CI: Must be true. Most CI environments already have this set by default.
#   2. $DOCKER_USERNAME: Your dockerhub username.
#   3. $DOCKER_PASSWORD: Your dockerhub password.

if [ "$CI" = true ] ; then
    docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
fi

docker push gldraphael/evlog
docker push gldraphael/evlog-self-contained
