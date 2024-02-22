# Setting up LocalDB on a Mac

There is no support for the development tool "LocalDB" on Mac to spin-up and run instances of MSSQL Server locally. This can be done on Windows, but is not recommended.

Instead, we can run a Docker container with the `SQL Azure Edge` image listening on the default SQL port, 1433, to set-up our development environment. This is practically the Mac equivalent of running the program LocalDB to spin-up MSSQL Server instances and even supports Apple Silicon chips.

[See the image on dockerhub for additional details, information, and troubleshooting](https://hub.docker.com/_/microsoft-azure-sql-edge)

---
# 1. Install Docker
You can install Docker by visiting [the official Docker webpage](https://www.docker.com/). Note that you do not have to be savvy in Docker whatsoever to enjoy employing this technique.

---
# 2. Use the Command, `docker pull ...` to download the Azure SQL Edge image

Ensure that the Docker application is running and use the following command in Terminal to download a new Azure SQL Edge container to the local image cache:

`docker pull mcr.microsoft.com/azure-sql-edge`

---
# 3. Use the Command, `docker run ...` to spin up a container using the Azure SQL Edge image

Firstly, determine a secure password to use prior to setting up your container. This password will be used in your connection string and I recommended keeping it as simple and secure as possible, while fulfilling three of four main conditions:

1. Password must contain a lowercase letter
2. Password must contain an uppercase letter
3. Password must contain a non-alphanumeric symbol
4. Password must contain a number

I recommend not using non-alphanumeric symbols to avoid having to escape them in your connection strings.

Once you have determined a sufficiently strong password, you are ready to spin up the container.

Run the following command in terminal, replacing the text appearing between the < and > symbol with your own values:

```zsh
docker run --cap-add SYS_PTRACE \
    -e 'ACCEPT_EULA=1' \
    -e 'MSSQL_SA_PASSWORD=<YOUR_PASSWORD_HERE>' \
    -e 'MSSQL_PID=Developer' \ 
    -p 1433:1433 \ 
    --name azuresqledge \
    -d \
    mcr.microsoft.com/azure-sql-edge
```

This will spin up the container automatically. You are now ready to form a connection string to the local database and begin developing for an MSSQL Server instance.

[Here is a list of other supported environment variables (from the SQL Server Docker ccontainer for Linux documentation)](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-configure-environment-variables?view=sql-server-ver16)

---
# 4. Form the Connection String

Form the connection string. Remember to replace text between the angular brackets, < and >, with your own value:

`Server=localhost;User Id=sa;Password=<YOUR_PASSWORD_HERE>;Initial Catalog=<YOUR_DATABASE_HERE or master>;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=True`

Note that the Server property uses `localhost` as opposed to `(localdb)`

This connection string will use the SA login, or SQL Administrator, giving the established connection unlimited access to the Server and tooling. The SA user can also create new SQL Users for more limited scope in testing or to divy up multiple environments living on the same local server, which may be desirable.

---
# 5. Use a SQL management tool to test the connection

In order to test your connection, you should install a SQL management tool which supports Azure SQL/Microsoft SQL Server. For Apple Silicon users, we can use Azure Data Studio.

[Learn more about and download Azure Data Studio here](https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&tabs=redhat-install%2Credhat-uninstall)

You also have the option of using a more universal SQL Management tool such as DBeaver.

Creating a new connection should prompt you to use either a credentials system or a connection string - in this case, you should choose 'connection string' in order to test the connection string which can then be reused in your application.

---
# Success

If you are able to connect to the server and run SQL commands, you have successfully launched the container and attached it to port 1433. This local database can be used to simulate SQL Server on your system for development.