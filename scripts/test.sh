#!/bin/bash

# Exit script as soon as a command fails.
set -o errexit

# Executes cleanup function at script exit.
trap cleanup EXIT

cleanup() {
  if [ -n "$ganache_pid" ] && ps -p "$ganache_pid" > /dev/null; then
    kill -9 "$ganache_pid"
  fi
}

ganache_is_running() {
  nc -z localhost "8545"
}

start_ganache() {
  if ganache_is_running; then
    echo "ganache-cli has already been started"
  else
    echo "Starting ganache-cli..."
    ganache-cli > /dev/null &
    ganache_pid=$!
    echo "Waiting for ganache-cli to start on port 8545..."

    while ! ganache_is_running; do
      sleep 0.1
    done

    echo "ganache-cli started"
  fi
}

start_ganache
dotnet test /p:CollectCoverage=true