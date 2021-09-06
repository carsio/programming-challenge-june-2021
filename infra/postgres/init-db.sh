#!/bin/bash
set -e

psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" <<-EOSQL
    CREATE DATABASE capiflix;
    GRANT ALL PRIVILEGES ON DATABASE capiflix TO postgres;
EOSQL
