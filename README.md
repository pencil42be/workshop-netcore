Glossary - https://docs.microsoft.com/en-us/dotnet/standard/glossary

# .net standard
- Vervangt PCL - Portable Class Libraries
- **Metafoor** - .net standard als interface met implementaties
  - https://github.com/dotnet/standard/blob/master/docs/metaphor.md
- Lagenmodel - .net standard in relatie tot runtimes
  - Voor .net standard
![Before](/assets/net-layers-before.png)
  - Na .net standard
![After](/assets/net-layers-after.png)
- Versies - https://docs.microsoft.com/nl-nl/dotnet/standard/net-standard
  ![VersionTable](/assets/net-standard-version-table-04-2018.png)
- Wanneer een .net standard lib maken?
  - hergebruik op >1 platform (.net core, .net fw, xamarin, UWP)
  - het is geen probleem als minder er API's beschikbaar zijn
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
    - zorgt er voor dat types gemapt worden naar platform types
  ![References](/assets/net-standard-type-forwarding.png)
  - Compatibility Shim
    - gebruikt type forwarding + een aparte dll om .NETFW dlls te gebruiken alsof ze net standard zijn
  ![References](/assets/net-standard-compat-shim.png)
- Eigen projecten / assemblies analyseren op compatibility?
  - [.NET Portability Analyzer](https://blogs.msdn.microsoft.com/dotnet/2014/08/06/leveraging-existing-code-across-net-platforms/)


# .net core
.net core is dus 1 van de 'implementaties' van .net standard 
- is een runtime met superset van netstandard API (zie versie tabel)
- is cross-platform (linux, mac, win - [Supported OS'es](https://github.com/dotnet/core/blob/master/release-notes/2.0/2.0-supported-os.md))
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


# asp.net core
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
Mogelijke aanpak =
- Razor voor alle views
- MVC voor alle API's
Zie ook https://stackify.com/asp-net-razor-pages-vs-mvc/

in VS2017
  - [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages/?tabs=visual-studio)
  - [MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?tabs=aspnetcore2x)

in VSCode
  - [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages-vsc/razor-pages-start)
  - [MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc)

in VS for Mac
  - [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages-mac/)
  - [MVC](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-mac/)


### asp.net core of classic asp.net? Wat te kiezen?

- voor containers met microservices is core de voor de hand liggende keuze
- zie https://docs.microsoft.com/en-us/aspnet/core/choose-aspnet-framework


### Configuratie & Startup
Het config model van asp.net core is verschillend van dat van web.config
- Startup.cs https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup
- Configuratie https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
- ASPNETCORE_ENVIRONMENT environment variabele
  - Zie ook https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments


### Dependency Injection (DI)
- Built-in DI in .net core - https://msdn.microsoft.com/en-us/magazine/mt707534.aspx
- Built-in asp.net core - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
- Vervangen door AutoFac?
  - .net core - http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
  - asp.net core - http://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html


### Middleware
Wat vroeger de asp.net pipeline was, is nu middleware
- intro - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?tabs=aspnetcore2x
- hoe globale exception handling doen?
  - per guidelines - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling#exception-handling-code
  - alt approach - https://scottsauber.com/2017/04/03/adding-global-error-handling-and-logging-in-asp-net-core/
  - filters - https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters#exception-filters


### Achtergrond taken
.net core ondersteunt 'hosted services' als background processing. Zowel in console app als in asp.net core.

Zie [dit msdn artikel](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/multi-container-microservice-net-applications/background-tasks-with-ihostedservice)

Hou er rekening mee dat dit verschilt tussen .net core 2.0 en 2.1 (geunificeerde api voor console en webapp)


# EF Core
- Speelt .net standard hier een rol?
  - EF Core >2 ' target' net standard 2.0 [link](https://docs.microsoft.com/nl-nl/ef/core/platforms/)
  - Dus je kan van je 'entity' lib een net standard 2.0 lib maken en hergebruiken
- [Start hier](https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db)
-  Full tutorial - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
- Mapping relationships
  - met fluent API - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#fluent-api-alternative-to-attributes
  - met attributes - https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#customize-the-data-model-by-using-attributes
- Injecting dbcontext - https://docs.microsoft.com/nl-nl/ef/core/get-started/aspnetcore/new-db#register-your-context-with-dependency-injection
- connectionstring voor package manager tools
  - via `IDesignTimeDbContextFactory<TContext>`
- Package Manager Console commands
  - https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell


# Setup ActiveMQ
- http://activemq.apache.org/getting-started.html
- zorg voor een compatibele JRE versie
  - http://www.oracle.com/technetwork/java/javase/downloads/jre10-downloads-4417026.html
  - set `JAVA_HOME`
- download latest version http://activemq.apache.org/download.html
- unzip en start - http://activemq.apache.org/getting-started.html#GettingStarted-StartingActiveMQStartingActiveMQ
- check http://127.0.0.1:8161/admin/ met admin/admin
- wanneer connectie maken van binnenin docker container, gebruik uw IP address, niet localhost

# Setup RabbitMQ in docker
https://gist.github.com/yetanotherchris/c954d1e8b688845c2dcdb3b33c94b2d2
```
docker run -d --hostname my-rabbit --name some-rabbit -p 4369:4369 -p 5671:5671 -p 5672:5672 -p 15672:15672 rabbitmq
docker exec some-rabbit rabbitmq-plugins enable rabbitmq_management
```

(met dank aan lv :)

# Amqp clients
Het voorbeeld is geschreven met [AmqpNetLite](http://azure.github.io/amqpnetlite/articles/building_application.html), maar het is mogelijk dat de [RabbitMQ client](http://rabbitmq.github.io/rabbitmq-dotnet-client/index.html) interessanter is. 

# run SQL server 2017 in docker
- zie https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker
- run (elevated powershell)
  - `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<min 8 char complex password>" -p 1401:1433 --name docker-sql-01 -d microsoft/mssql-server-linux:2017-latest`
  - dit geval is nu op poort 1401, dus voeg `,1401` aan je servernaam toe in connectionstring

# PakjesDienst Project
Als voorbeeld gebruiken we een fictieve pakjesdienst. Een verzender kan een pakje registreren, te verzenden via een koerierdienst en te leveren aan een bestemmeling. De koerierdienst kan de status en voorziene levertijd van het pakje aanpassen. De bestemmeling kan berichten ontvangen wanneer de status of levertijd van het pakje aangepast wordt.

![References](/assets/pakjesdienst-overzicht.png)

De applicatie bestaat uit een database, een queue of eventhub, een web api en een web applicatie. Alles kan in containers ge-deployed worden.

Een ander domein kan ook gerust gebruikt worden. Maak het niet te complex om mee te beginnen en voeg dan naar eigen smaak technische of functionele complexiteit toe.

## Oefeningen
(niet in volgorde, niet exhaustief, pick & mix & voeg zelf toe wat je wil)
- bouw de apps op vanaf 0, op basis van bovenstaande uitleg
- of gebruik het voorbeeld en breid het uit
- voeg automapper toe
- voeg een javascript front-end toe die de rest api aanspreekt en de signalr berichten ontvangt en toont
- stuur de signalr berichten enkel naar specifieke gebruikers
  - gebruik de signalr ConnectionId en de naam van de Bestemmeling
- deploy een amqp compatibele server in een container (activemq of rabbitmq)
- zet de 'environment' voor asp.net core in de container of container orchestrator/host
- voeg authenticatie toe, e.g. op basis van identityserver4
- voeg in de api razorpages toe voor de verzender en koerier of bouw een aparte app die de api aanspreekt
- transformeer de appsettings.production.json in een build/release flow waarbij enkel de tool de juiste config kent
- maak een uwp of xamarin app die libraries van deze app hergebruikt
- een andere amqp client gebruiken bijvoorbeeld RabbitMQ)
- pub/sub doen ipv queues, bijvoorbeeld met [RabbitMQ](http://www.rabbitmq.com/tutorials/tutorial-three-dotnet.html)
- 1 of meer relaties toevoegen aan het model
  - laat een Verzender pakjes volgen
  - laat een Bestemmeling eerdere pakjes opvragen
  - laat een Verzender of een Koerier meerdere pakjes bundelen in een Levering
  - laat een Verzender kiezen uit een lijst van Koeriers
  - ...

## NSwag
Swagger-ui voor je API
- Makkelijk te gebruiken als developer interface, configureerbaar
- Injecteerbaar als middleware
- Kan user authenticatie faciliteren in UI
- Kan ook enkel docs genereren ipv ook de API aan te roepen (ReDoc)
- Kan dienen als developer portal / SDK

Home: https://github.com/RSuter/NSwag
Gebruiken in asp.net core: https://github.com/RSuter/NSwag/wiki/Middlewares

  

## AutoMapper
Veelgebruikte lib voor Dto's die extern 'contract' mappen op interne types
- http://aspnetcorepath.com/automapper-in-asp-net-core-2/


## SignalR
Real-time communicatie naar clients
- zoals op asp.net core 2.1 (preview!)
- getting started - https://docs.microsoft.com/nl-nl/aspnet/core/signalr/get-started?tabs=visual-studio
- sample app -  https://github.com/aspnet/signalr-samples/blob/master/ChatSample/ChatSample/ChatHub.cs
- stuur vanaf controller naar signalR - [SO Question](https://stackoverflow.com/questions/46904678/call-signalr-core-hub-method-from-controller)
- stuur naar specifieke client via ConnectionId zie ook [artikel](https://damienbod.com/2017/12/05/sending-direct-messages-using-signalr-with-asp-net-core-and-angular/)

# Lectuur achteraf
[e-Shop on containers](https://github.com/dotnet-architecture/eShopOnContainers) is een demo applicatie van Microsoft specifiek gericht op microservices.

[Microservices book](https://docs.microsoft.com/nl-nl/dotnet/standard/microservices-architecture/) beschrijft een aantal technieken voor microservices op het .net core platform en maakt gebruik van eShopOnContainers als voorbeeld.