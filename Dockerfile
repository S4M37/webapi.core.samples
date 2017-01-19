FROM ubuntu:16.04
MAINTAINER sametoussema@gmail.com

RUN apt-get update && apt-get install -y supervisor
RUN mkdir -p /var/log/supervisor /usr/bin/webapi.core.mongo /usr/bin/webapi.core.welcome

RUN sh -c 'echo "deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list' 
RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
RUN apt-get update 
RUN apt-get -y install dotnet-dev-1.0.0-preview2.1-003177


## before build this Dockerfile, make sure u build and publish the solutions
#
# dotnet build ./src/webapi.core.welcome
# dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.welcome
#
# dotnet build ./src/webapi.core.mongo
# dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.mongo	
#
# dotnet build ./src/webapi.core.entityframework
# dotnet publish -f netcoreapp1.0 -r ubuntu.16.04-x64 -c Debug ./src/webapi.core.entityframework	
#

COPY ./src/webapi.core.mongo/bin/Debug/netcoreapp1.0/ubuntu.16.04-x64/publish /usr/bin/webapi.core.mongo/

COPY ./src/webapi.core.welcome/bin/Debug/netcoreapp1.0/ubuntu.16.04-x64/publish /usr/bin/webapi.core.welcome/

COPY ./src/webapi.core.welcome/bin/Debug/netcoreapp1.0/ubuntu.16.04-x64/publish /usr/bin/webapi.core.entityframework/

WORKDIR /usr/bin

EXPOSE 5000 5001 5002

ADD supervisord.conf /etc/supervisor/conf.d/supervisord.conf 

ENTRYPOINT ["/usr/bin/supervisord"]