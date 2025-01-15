FROM mcr.microsoft.com/dotnet/sdk:6.0.428-1-focal-amd64 AS build     
WORKDIR /src
COPY MyMicroservice.csproj .
RUN dotnet restore
COPY . .

RUN dotnet publish -c Release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:6.0.36   

WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "MyMicroservice.dll"]