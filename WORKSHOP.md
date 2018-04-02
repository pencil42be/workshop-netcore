#### .net core
- Entrypoint
  - https://docs.microsoft.com/en-us/dotnet/core/
- Getting started
- .net Core CLI
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
- .net Core in Visual Studio
- .net Core in VsCode

- .net Core in VS for Mac
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-macos
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-mac-vs-full-solution


#### .net standard
- **Metafoor** - .net standard als interface met implementaties
- Lagenmodel - .net standard in relatie tot 


https://github.com/thangchung/awesome-dotnet-core

#### asp.net core
- in VS2017
- in VSCode
- in VS for Mac

Razor vs MVC vs Web Api

asp.net core vs classic asp.net
https://docs.microsoft.com/en-us/aspnet/core/choose-aspnet-framework

#### Dependency Injection (DI)
- Built-in - https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
- Built-in asp.net core - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
- AutoFac
  - .net core - http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
  - asp.net core - 

#### EF Core
- Is .net standard van belang hier?
- Start - https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db
-  Full tutorial - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
- Mapping relationships
  - fluent - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#fluent-api-alternative-to-attributes
  - attributes - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#customize-the-data-model-by-using-attributes
- Injecting dbcontext - https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db#register-your-context-with-dependency-injection
- connectionstirng voor package manager tools

#### AutoMapper
- http://aspnetcorepath.com/automapper-in-asp-net-core-2/

#### Setup ActiveMQ
- http://activemq.apache.org/getting-started.html
- make sure you have a compatible JRE version
  - http://www.oracle.com/technetwork/java/javase/downloads/jre10-downloads-4417026.html
  - set JAVA_HOME
- download latest version http://activemq.apache.org/download.html
- unzip and start - http://activemq.apache.org/getting-started.html#GettingStarted-StartingActiveMQStartingActiveMQ
- check http://127.0.0.1:8161/admin/ with admin/admin
- when accessing from inside a docker container, use your computer's IP address, not localhost

#### run SQL server 2017 in docker
- see https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker
- run (elevated powershell)
  - docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<8 char complex password>" -p 1401:1433 --name docker-sql-01 -d microsoft/mssql-server-linux:2017-latest
  - this runs on port 1401, so append ,1401 to servername in connectionstring

#### NSwag
- https://github.com/RSuter/NSwag
- in asp.net core: https://github.com/RSuter/NSwag/wiki/Middlewares

#### SignalR
- zoals op asp.net core 2.1 (preview!)
- getting started - https://docs.microsoft.com/nl-nl/aspnet/core/signalr/get-started?tabs=visual-studio
- sample app -  https://github.com/aspnet/signalr-samples/blob/master/ChatSample/ChatSample/ChatHub.cs
- stuur vanaf controller naar signalR - https://stackoverflow.com/questions/46904678/call-signalr-core-hub-method-from-controller

#### Middleware
- intro - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x
- exception handling
  - per guidelines - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling#exception-handling-code
  - alt approach - https://scottsauber.com/2017/04/03/adding-global-error-handling-and-logging-in-asp-net-core/
  - filters - https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#exception-filters
  