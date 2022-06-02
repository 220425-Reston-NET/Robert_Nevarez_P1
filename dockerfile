#From instruction will tell docker engine that this image will depend on this SDK to run

from mcr.microsoft.com/dotnet/sdk:6.0 as build

#workdir docker instruction let use create what our working directory will be for image
workdir /app

#copy docker 
copy *.sln ./
copy LeagueStoreApi/*.csproj LeagueStoreApi/
copy LeagueStoreBL/*.csproj LeagueStoreBL/
copy LeagueStoreDL/*.csproj LeagueStoreDL/
copy LeagueStoreModel/*.csproj LeagueStoreModel/
copy LeagueStoreTest/*.csproj LeagueStoreTest/

#Now we will copy the rest after setting up our project structure
copy . ./

#Restoring our bin and obj file
#Run docker instructure will run a CLI command in the image
run dotnet build

#It will create a publish folder that will hold all the information to be able to run your application
run dotnet publish -c Release -o publish

#multi-stage build in Docker
#It allows us to have multiple ways to create our application
#The first stage was all about building our application hence why we need an SDK
#ultimetely it was just to run dotnet build and dotnet publish
 
from mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

workdir /app

copy --from=build /app/publish ./

cmd ["dotnet", "LeagueStoreApi.dll"]

#expose to port 80
expose 80
