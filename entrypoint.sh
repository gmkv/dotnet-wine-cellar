#!/bin/bash
set -e
run_cmd="dotnet run --server.urls http://*:80"

until dotnet ef database update; do
>&2 echo "Server is starting up"
sleep 1
done

>&2 echo "executing"
exec $run_cmd
