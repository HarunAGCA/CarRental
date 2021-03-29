FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY Core/*.csproj ./Core/
COPY Entities/*.csproj ./Entities/
COPY DataAccess/*.csproj ./DataAccess/
COPY Business/*.csproj ./Business/
COPY WebAPI/*.csproj ./WebAPI/ 
#
RUN dotnet restore 
#
# copy everything else and build app
COPY Core ./Core
COPY Entities ./Entities
COPY DataAccess ./DataAccess
COPY Business ./Business
COPY WebAPI ./WebAPI

#
WORKDIR /app/
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 
#
COPY --from=build /app/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAPI.dll