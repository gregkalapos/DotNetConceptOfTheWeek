
#Sample 1 - build on dev. machine, run within a container
#FROM microsoft/aspnetcore-build:2.0 AS final
#WORKDIR /app
#COPY /WebApplication5/bin/Debug/netcoreapp2.0 .


#Sample 2 - build on dev. machine, run within a container, runtime image
#FROM microsoft/aspnetcore:2.0 AS final
#WORKDIR /app
#COPY /WebApplication5/bin/Debug/netcoreapp2.0 .


FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

#Sample 3 - build in a container, run in another container
#FROM microsoft/aspnetcore-build:2.0 AS build
#WORKDIR /src
#COPY *.sln ./
#COPY 10_AspNetCoreDocker/DockerSample/DockerSample.csproj 10_AspNetCoreDocker/DockerSample/
#RUN dotnet restore
#COPY . .
#WORKDIR /src/10_AspNetCoreDocker/DockerSample
#RUN dotnet build -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "DockerSample.dll"]


#Sample 4, build in a container, run in another container, .NET Core 2.1 with Aline Linux
FROM microsoft/dotnet:2.1-runtime-alpine AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /src
#COPY *.sln ./
COPY DockerSample.csproj DockerSample/
#RUN dotnet restore
COPY . .
WORKDIR .
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c  Release -o /l/linux -r linux-x64
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /l/linux/libuv.so .
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerSample.dll"]
