#!/bin/bash

set -e

docker build -t bpp-build support/
docker run --user=`id -u`:`id -g` -i -v $PWD:/b-plus-plus -t -w /b-plus-plus bpp-build make coverage
