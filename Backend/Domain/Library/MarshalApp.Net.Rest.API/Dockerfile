#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/Domain/Library/MarshalApp.Net.Rest.API/MarshalApp.Net.Rest.API.csproj", "Backend/Domain/Library/MarshalApp.Net.Rest.API/"]
COPY ["Backend/Domain/Library/MarshalApp.Net.Rest.Data/MarshalApp.Net.Rest.Infrastructure.Data.csproj", "Backend/Domain/Library/MarshalApp.Net.Rest.Data/"]
COPY ["Backend/Domain/Library/MarshalApp.Net.Rest.Infrastructure/MarshalApp.Net.Rest.Infrastructure.CrossCutting.csproj", "Backend/Domain/Library/MarshalApp.Net.Rest.Infrastructure/"]
RUN dotnet restore "Backend/Domain/Library/MarshalApp.Net.Rest.API/MarshalApp.Net.Rest.API.csproj"
COPY . .
WORKDIR "/src/Backend/Domain/Library/MarshalApp.Net.Rest.API"
RUN dotnet build "MarshalApp.Net.Rest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarshalApp.Net.Rest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarshalApp.Net.Rest.API.dll"]