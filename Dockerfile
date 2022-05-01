FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src

COPY . .

RUN dotnet restore

FROM build as publish
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT [ "dotnet", "RecipeManager.Host.dll" ]