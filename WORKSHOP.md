Glossary - https://docs.microsoft.com/en-us/dotnet/standard/glossary

#### .net standard
- Vervangt PCL
- Versies - https://docs.microsoft.com/nl-nl/dotnet/standard/net-standard
  ![VersionTable](/assets/net-standard-version-table-04-2018.png)
- **Metafoor** - .net standard als interface met implementaties
  - https://github.com/dotnet/standard/blob/master/docs/metaphor.md
- Lagenmodel - .net standard in relatie tot runtimes
  - Voor .net standard
![Before](/assets/net-layers-before.png)
  - Na .net standard
![After](/assets/net-layers-after.png)
- Wanneer een .net standard lib maken?
  - hergebruik op >1 platform (.net core, .net fw, xamarin, UWP)
  - ok als minder API's beschikbaar
- Wanneer een .net core lib maken?
  - als alleen gebruikt op .net core
  - meer API's nodig
- Wat kunnen we referencen vanuit netstandard lib?
   ![References](/assets/net-standard-references.png)
  - netstandard (of PCL)
  - net framework via compat shim
    - zie ook https://github.com/dotnet/standard/tree/master/docs/netstandard-20#assembly-unification
    - type forwarding door msbuild toegevoegd waar nodig
  - Type Forwarding
  ![References](/assets/net-standard-type-forwarding.png)
  - Compatibility Shim
  ![References](/assets/net-standard-compat-shim.png)
- Eigen projecten / assemblies analyseren op compatibility?
  - [.NET Portability Analyzer](https://blogs.msdn.microsoft.com/dotnet/2014/08/06/leveraging-existing-code-across-net-platforms/)

#### .net core
.net core is dus 1 van de 'implementaties' van .net standard
- runtime met superset van netstandard API (zie versie tabel)
- cross-platform
- CLI tools + VS tools (Full VS, VSCode, VS for Mac)

Documentatie-urls
- Entrypoint docs
  - https://docs.microsoft.com/en-us/dotnet/core/
- .net Core CLI
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli
- .net Core in Visual Studio
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio
- .net Core in VsCode
  - https://code.visualstudio.com/docs/other/dotnet
  - https://docs.microsoft.com/nl-nl/dotnet/core/tutorials/with-visual-studio-code
- .net Core in VS for Mac
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-macos
  - https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-mac-vs-full-solution

Zie ook deze lijst van .net core libraries, tools etc...
https://github.com/thangchung/awesome-dotnet-core

.net core of .Net Framework?
https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server


#### asp.net core
Vroeger gekend als ASP.NET 5 en de start van .NET core.
Er is geen web api meer, alleen nog mvc.

[Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages)

Razor pages vs MVC
- Razor =~ MVVM
- MVC kan makkelijk de combo maken tussen server-side pages en client-side javascript apps
- Razor = enkel server-side
- Razor is eenvoudiger, minder gebaseerd op naming conventions (e.g. 'Home' View + HomeController)
- Razor doet denken aan klassieke 'Web Forms' maar er is geen postback

(opinie) Razor is een tegenreactie tegen de soms complexe structuur van MVC apps waarbij je vaak moet zoeken in de src code op basis van naming conventions.
- mogelijke aanpak =
  - Razor voor alle views
  - MVC voor alle API's
Zie ook https://stackify.com/asp-net-razor-pages-vs-mvc/

- in VS2017

- in VSCode
  - [Razor](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages-vsc/razor-pages-start)
  - [MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc)
- in VS for Mac
TODO

asp.net core vs classic asp.net
https://docs.microsoft.com/en-us/aspnet/core/choose-aspnet-framework

#### Configuratie & Startup
- Startup.cs https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup
- Configuratie https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
- ASPNETCORE_ENVIRONMENT environment variabele
  - Zie ook https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments


#### Dependency Injection (DI)
- Built-in DI in .net core - https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
- Built-in asp.net core - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
- Vervangen door AutoFac?
  - .net core - http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
  - asp.net core - http://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html


#### Middleware
- intro - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x
- exception handling
  - per guidelines - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling#exception-handling-code
  - alt approach - https://scottsauber.com/2017/04/03/adding-global-error-handling-and-logging-in-asp-net-core/
  - filters - https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#exception-filters


#### EF Core
- Is .net standard van belang hier?
  - EF Core >2 ' target' net standard 2.0 [link](https://docs.microsoft.com/nl-nl/ef/core/platforms/)
  - Dus je kan van je 'entity' lib een net standard 2.0 lib maken en hergebruiken
- [Start hier](https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db)
-  Full tutorial - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
- Mapping relationships
  - fluent - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#fluent-api-alternative-to-attributes
  - attributes - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#customize-the-data-model-by-using-attributes
- Injecting dbcontext - https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db#register-your-context-with-dependency-injection
- connectionstring voor package manager tools
- Package Manager Console commands
  - https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell


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
Swagger-ui voor je API
Makkelijk te gebruiken als middleware, configureerbaar
Kan user authenticatie faciliteren in UI
Kan ook enkel docs genereren ipv ook de API aan te roepen (ReDoc)
Kan dienen als developer portal / SDK

Home: https://github.com/RSuter/NSwag
Gebruiken in asp.net core: https://github.com/RSuter/NSwag/wiki/Middlewares

  

#### AutoMapper
Veelgebruikte lib voor Dto's die extern 'contract' mappen op interne types
- http://aspnetcorepath.com/automapper-in-asp-net-core-2/


#### SignalR
Real-time communicatie naar clients
- zoals op asp.net core 2.1 (preview!)
- getting started - https://docs.microsoft.com/nl-nl/aspnet/core/signalr/get-started?tabs=visual-studio
- sample app -  https://github.com/aspnet/signalr-samples/blob/master/ChatSample/ChatSample/ChatHub.cs
- stuur vanaf controller naar signalR - https://stackoverflow.com/questions/46904678/call-signalr-core-hub-method-from-controller
- stuur naar specifieke client via ConnectionId zie ook [artikel](https://damienbod.com/2017/12/05/sending-direct-messages-using-signalr-with-asp-net-core-and-angular/)