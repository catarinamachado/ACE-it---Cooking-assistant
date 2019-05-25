
# ACE it - Cooking Assistant

## Setup Docker Sql Server database

* `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Pass@word' -p 5433:1433 -d microsoft/mssql-server-linux:2017-latest`

* Edit ACE-it/appsettings.json to add your password to the Sql Server

* `dotnet ef database update`

## Setup frontend dependencies

### JS packages from libman

* `dotnet tool install -g Microsoft.Web.LibraryManager.Cli`
* `libman restore`


### Microsoft SpeechSDK-JavaScript

In the `ACE-it/ACE-it/wwwroot/lib` folder:

* `wget https://csspeechstorage.blob.core.windows.net/drop/1.5.0/SpeechSDK-JavaScript-1.5.0.zip`
* `unzip SpeechSDK-JavaScript-1.5.0.zip`
