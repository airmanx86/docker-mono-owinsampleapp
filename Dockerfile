# DOCKER-VERSION 1.1.2
FROM    nintexteamio/mono-base:latest
MAINTAINER Arthur Ho

# Build dependencies
ADD app/ .
EXPOSE 9000
CMD ["mono", "OwinSampleApp.exe", "9000"]