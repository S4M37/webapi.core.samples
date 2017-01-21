# WebApi .NET Core V1.1.0 samples

This repository is a set of Web Api samples developed using .NET Core V1.1.0. We are using Xunit for unit test
### Quick start
Make sure you have .Net Core >= 1.1.0 
> Clone/Download the repo 

```bash
# clone our repo
# --depth 1 removes all but one .git commit history
git clone --depth 1 https://github.com/S4M37/webapi.core.samples.git

# change directory to our repo
cd webapi.core.samples

# restore packages and install dependencies
dotnet restore

# build the solution
dotnet build ./src/{project_dir}

# start one of the desired project
cd ./src/{project_dir}
dotnet run 

```
go to [http://0.0.0.0:5000](http://0.0.0.0:5000) or [http://localhost:5000](http://localhost:5000) in your browser if webapi.core.welcome

go to [http://0.0.0.0:5001](http://0.0.0.0:5001) or [http://localhost:5001](http://localhost:5001) in your browser if webapi.core.mongo

go to [http://0.0.0.0:5002](http://0.0.0.0:5002) or [http://localhost:5002](http://localhost:5002) in your browser if webapi.core.entityframework

* [Getting Started](#getting-started)
    * [Installing](#installing)
    * [Running the app](#running-the-app)
    * [Unit Test](#unit-test)
    * [Build Docker](#build-docker)

## File Structure
we use the template provided by visual studio WebApi .NET Core here how it looks:
```
webapi.core.samples/
 |                  
 |──global.json
 |
 |──src
 |  |──webapi.core.entityframework
 |  |  |──...
 |  |  |__project.json
 |  |
 |  |──webapi.core.mongo
 |  |  |──...
 |  |  |__project.json
 |  |
 |  |__webapi.core.welcome
 |  |  |──...
 |     |__project.json
 |    
 |
 |__test
    |__core.xunit
       |──...
       |──Test Files
       |__project.json
       
```

## Installing
* `fork` this repo
* `clone` your fork
* `dotnet restore` to restore packages, intall dependencies
* `dotnet build ./src/{project_dir}` to build the solution


## Running the app
After you have installed all dependencies you can now run the app. Move to one of the project`cd /src/{project_dir}` and run `dotnet run` to start a local server using `webpack-dev-server` . The port will be displayed to you as `http://0.0.0.0:5000` (webapi.core.welcome)
>To run webapi.core.mongo you need to have a mongo server running, if you don't, you can easilypull a docker image with `docker pull mongo` and run it wth `docker run -p 24017:24017 --name mongoDB mongo`

## Unit Test
For unit test we use XUnit. check for more details [http://xunit.github.io/docs/getting-started-dotnet-core](http://xunit.github.io/docs/getting-started-dotnet-core).
* `dotnet test /test/core.xunit` add `-xml ./test/core.xunit/xunit-report.xml` to generate a test report 


## build docker
> the result docker container runs all the solutions together, they are managed by a supervisor. check supervisord.conf

>don't forget to have mongo server running, if you don't, just run `docker run -p 24017:24017 --name mongoDB mongo `

```bash
## before build this Dockerfile, make sure you build and publish the solutions

dotnet build ./src/webapi.core.welcome
dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.welcome

dotnet build ./src/webapi.core.mongo
dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.mongo	

dotnet build ./src/webapi.core.entityframework
dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.entityframework


##build the image
docker build -t webapi.core.image .

##run the container
docker run -p 5000:5000 -p 5001:5001 -p 5002:5002 --name webapi.core.server webapi.core.image
```
