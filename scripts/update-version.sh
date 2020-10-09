#!/bin/bash

project="$1"

echo "Calculating version for $project..."

version=$(nbgv get-version -p ./src/"$1" -v NuGetPackageVersion)

echo "$project version is '$version'"
echo "Updating $project.csproj..."

sed -i.bak -e "s/<Version>.*<\\/Version>/<Version>$version<\\/Version>/g" ./src/"$project"/"$project".csproj

echo "Done"