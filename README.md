# RecipeManager.Server

## About

Provides an API for managing recipes. Used as the backend for [Recipe Manager](https://github.com/JedS6391/RecipeManager.Web).

## Development

Follow the instructions below to get started with the project in a local development environment.

### Prerequisites

* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
* [Docker](https://www.docker.com/)

### Building

```console
dotnet build
```

### Running

A Docker compose file is provided that can be used to start a development instance of the server, including the web API and a SQL Server instance.

```console
docker-compose build

# Start the web service and a SQL server instance
docker-compose up
```

A `.env` file will need to be created with the following variables defined for `docker-compose`:

* SQL_PASSWORD - the password use for the SQL Server `sa` user
* CONNECTION_STRING - the connection string provided to the service (e.g. `User ID=sa;Password=...;Initial Catalog=RecipeManager;Server=...`)

Once the server is running, the database can be created with the `create-dev-db.sh` script:

```console
# Creates the database and associated tables
docker exec -i ${container-name} bash < create-dev-db.sh
```

## Deployment

TODO
