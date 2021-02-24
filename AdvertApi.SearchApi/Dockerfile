FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS build
WORKDIR /src

COPY *.csproj .
RUN dotnet restore 

COPY . .
RUN dotnet publish -c release -o /app --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "AdvertApi.Search.Api.dll"]