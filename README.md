
# ACE it - Cooking Assistant

## Setup Docker Sql Server database

* `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pass@word' -p 5433:1433 -d microsoft/mssql-server-linux:2017-latest`

* Edit ACE-it/appsettings.json to add your password to the Sql Server

* `dotnet ef database update`

