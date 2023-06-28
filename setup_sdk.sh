#!/bin/bash

set -e
testDir="dotnet-sdk-test"
GREEN="\033[0;32m"
NC="\033[0m"

if [ ! $PLIVO_API_PROD_HOST ] || [ ! $PLIVO_API_DEV_HOST ] || [ ! $PLIVO_AUTH_ID ] || [ ! $PLIVO_AUTH_TOKEN ]; then
    echo "Environment variables not properly set! Please refer to Local Development section in README!"
    exit 126
fi

cd /usr/src/app

echo "Setting plivo-api endpoint to dev..."
find /usr/src/app/src/Plivo/Client -type f -exec sed -i "s/$PLIVO_API_PROD_HOST/$PLIVO_API_DEV_HOST/g" {} \;

if [ ! -d $testDir ]; then
    echo "Creating test dir..."
    mkdir -p $testDir
fi

if [[ $( grep "Plivo.NetCore.Test" Plivo.sln ) ]]; then
    # Fix for library issue: See Dotnet section of https://plivo-team.atlassian.net/wiki/spaces/SMSTEAM/pages/3581313044/Local+Setup+for+SDKs
    sed -i '/Nerdbank.GitVersioning/ {
        n;
        /Version/ {
            s/<Version>[^<]*<\/Version>/<Version>3.4.244<\/Version>/g;
        }
    }' Directory.Build.props
    sed -i '/Plivo.NetCore.Test/,+1d' Plivo.sln
fi

if [ ! -f $testDir/*.csproj ]; then
    echo "Initialising test project"
    cd $testDir
    dotnet new console
    dotnet add package Plivo
    sed -i 's+<PackageReference Include="Plivo".*>+<ProjectReference Include="/usr/src/app/src/Plivo/Plivo.csproj"/>+' $testDir.csproj
    echo "using Plivo;" > Program.cs
    dotnet restore
fi

echo -e "\n\nSDK setup complete! You can test changes either on host or inside the docker container:"
echo -e "\ta.To test your changes ON HOST:"
echo -e "\t\t1. Add your test code to <path_to_cloned_sdk>/$testDir/Program.cs"
echo -e "\t\t2. Run your test file using: $GREEN make run CONTAINER=$HOSTNAME$NC"
echo
echo -e "\tb. To test your changes INSIDE CONTAINER:"
echo -e "\t\t1. Run a terminal in the container using: $GREEN docker exec -it $HOSTNAME /bin/bash$NC"
echo -e "\t\t2. Add your test code in /usr/src/app/$testDir/Program.cs"
echo -e "\t\t3. Run your test file using: $GREEN make run$NC"

# To keep the container running post setup
/bin/bash