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
`docker run -it -p 3000:80 --name <container-name> <image-name>`

Extras: 

-> Flags description: 
`-i` : Activa el modo interactivo
`-t` : Hace que la experiencia interactiva sea más similar a trabajar en una terminal real.
`--rm` : Elimina automáticamente el contenedor cuando se detiene.
`-p 3000:80` : Mapea el puerto 3000 del host al puerto 80 dentro del contenedor.
`-d` : Modo daemon, lo ejecuta en segundo plano hasta ser detenido manualmente con `docker stop <container-name>`. 

-> Useful commands: 
`docker ps` ver contenedores activos