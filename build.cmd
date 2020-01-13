dotnet restore --verbosity Minimal
dotnet build -p:Copyright="2020 Bytewizer.  All rights reserved." --version-suffix prebuild.100 --no-restore --verbosity Minimal --configuration Release
dotnet pack -p:Copyright="2020 Bytewizer.  All rights reserved." --version-suffix prebuild.100 --include-symbols --no-restore --no-build --verbosity Minimal --configuration Release --output .builds/artifacts