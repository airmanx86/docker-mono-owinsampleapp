# DOCKER-VERSION 1.1.2
FROM    nintexteamio/mono-base:latest
MAINTAINER Arthur Ho

# Build dependencies
##ADD app/ .
ADD src/ ./src
RUN mkdir ./app
RUN cd /src; xbuild /p:Configuration=Release "OwinSampleApp/OwinSampleApp.csproj" /p:OutputPath="./app"
RUN rm -rf ./src
EXPOSE 9000
CMD ["mono", "./app/OwinSampleApp.exe", "9000"]