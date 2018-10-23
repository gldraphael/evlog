#!/bin/bash

# Source: https://gist.github.com/JonCanning/a083e80c53eb68fac32fe1bfe8e63c48

regex='PackageReference Include="([^"]*)" Version="([^"]*)"'
find . -name "*.*proj" | while read proj
do
  while read line
  do
    if [[ $line =~ $regex ]]
    then
      name="${BASH_REMATCH[1]}"
      version="${BASH_REMATCH[2]}"
      if [[ $version != *-* ]]
      then
        dotnet add $proj package $name
      fi
    fi
  done < $proj
done