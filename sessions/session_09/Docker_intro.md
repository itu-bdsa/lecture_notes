# Intro to a local SQL Server with Docker


- Install Docker on your computer. Follow the [official installation guide](https://docs.docker.com/engine/installation/).
- There is a quickstart guide on hot to [run SQL Server container images with Docker](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker).

The most important steps in it are:


## Run a SQL Server database

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" \
   -p 1433:1433 --name sql1 --hostname sql1 \
   -d \
   mcr.microsoft.com/mssql/server:2022-latest
```

That should setup, configure, and startup a database server that you can use for local development.

## See if the SQL Server database is up and running

```bash
docker ps -a
```
If the database engine is working correctly, the command above should produce output as in the following. The important piece of information is the `STATUS`, which is `Up`.

```bash
CONTAINER ID   IMAGE                                        COMMAND                    CREATED         STATUS         PORTS                                       NAMES
9affe39effe5   mcr.microsoft.com/mssql/server:2022-latest   "/opt/mssql/bin/perm..."   4 minutes ago   Up 4 minutes   0.0.0.0:1433->1433/tcp, :::1433->1433/tcp   sql1
```
- In case the `STATUS` starts with `Exited` then the database server is not up and running.
- If the container with the SQL Server is `Up`, then you should be able to connect to the database from code with a connection string as in the following:
  ```
  "Server=127.0.0.1,1433;
  Database=Master;
  User Id=SA;
  Password=<YourStrong@Passw0rd>";
  ```

## Stopping, removing, and thereby wiping a database

```bash
docker stop sql1
docker rm sql1
```
