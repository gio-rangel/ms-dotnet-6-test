### LEVANTAR SERVICIO DOCKER ###
----------------------------------------
Chequear doc para microservicios: 
https://dotnet.microsoft.com/en-us/learn/aspnet/microservice-tutorial/intro
--------------------------------------------
*Preview steps y consideraciones*:

-> SDK:
Último SDK lts para .Net 6 tiene version 6.0.428
pero no existe una imagen con esta notacion exacta para esta version
se uso: `mcr.microsoft.com/dotnet/sdk:6.0.428-1-focal-amd64` para descargar el sdk correspondiente.
Para consultar otras versiones de imagenes ir a Microsoft Artifact Registry: mcr.microsoft.com


-> Runtime: 
El runtime usado para esta version es el 6.0.36 por lo que tenemos que indicar en la imagen que utilice
`mcr.microsoft.com/dotnet/aspnet:6.0.36`
----------------------------------------------

1. Basado en la imagen que esta en el Dockerfile ejectamos el comando para crearla. 

`docker build -t <image-name>.` 

Colocar un nombre representativo para la imagen como puede ser 'microservice1'... 

2. Luego asociamos la imagen a un contenedor ejecutando: 
`docker run -it -d -p 3000:80 --name <container-name> <image-name>`

Extras: 

-> Flags description: 
`-i` : Activa el modo interactivo
`-t` : Hace que la experiencia interactiva sea más similar a trabajar en una terminal real.
`--rm` : Elimina automáticamente el contenedor cuando se detiene.
`-p 3000:80` : Mapea el puerto 3000 del host al puerto 80 dentro del contenedor.
`-d` : Modo daemon, lo ejecuta en segundo plano hasta ser detenido manualmente con `docker stop <container-name>`. 

-> Useful commands: 
`docker ps` ver contenedores activos

---------------------------------
### DOCKER COMPOSER ###
source: 
https://raw.githubusercontent.com/confluentinc/cp-all-in-one/6.1.1-post/cp-all-in-one/docker-compose.yml

Set up in a docker-compose.yml all the services configuration for kafka ecosystem 

*ZooKeeper:* 
Serves as a centralized service for managing distributed systems. 
It plays a key role in coordinating and managing the metadata, 
configurations, and distributed nature of Kafka clusters.

*broker*: 
This service handles message streams between producers and consumers.

*schema-registry*:
Resposinble for data validation in kafka topics.

*connect*: 
conect and move date between kafka services.

*control-center*: 
its the UI for interacting and visualize the performance of the kafka ecosystem. 
There we can create topics and manage the incoming data for each topic. 

*ksqldb-server*:
Is a SQL-based streaming platform built on top of Apache Kafka. 
It allows developers to query, process, and transform streaming data 
in real-time using SQL-like syntax, without the need to write complex code. 
The ksqldb-server is the engine that processes these SQL queries and interacts with Kafka to perform its operations.

*ksqldb-cli*:
Command line for ksqldb-server. 

*datagen*:
Allow to generate data testing samples for populating kafka topics.

*rest-proxy*:
Allow to interact with kafka topis using http requests.
Act as an intermediate between services and the outside. 
