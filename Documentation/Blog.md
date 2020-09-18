# Blog

2020-09-14

Vi började att skapa ett Azureprojekt där vi bjöd in alla medlemmar. Därefter började vi med dokumentationen.

I Google Drive skapade vi en delbar mapp med Google Teckningar dokument. Dessa delades upp i olika delar såsom Piplelinedesign, Databasdesign, Funktionaltetsdesign mm. Tänkt att i dessa skissa upp olika flödeschema. Vi hann klart med en skiss över hur vi initialt tänkt oss vår Pipelinedesign.

Ett Github-repo har skapats med ett .Net Core API projekt som laddats upp till Github. Fortsatt planering för att komma överens om "gruppregler", flödeschema mm. fortsätter efterkommande dag. 

2020-09-15

Fortsatt arbete med processerna och gruppreglerna. Följande processer är klara:

- Process för gemensam hantering av github klar tillsammans med flödesschema. 
- Databasdesign som skall kodas upp via Code First. Vi använde **Management Studio** till detta, då det går snabbt att skissa upp Tables, Attribut och Relationer.
- Schematider för gruppen
- Funktionalitetsdesign
- Build pipeline igång. Kan behövas eventuell konfigurering senare.

##### Pipeline

Vi började skapa en simpel build-pipeline, med .Net Core som build Target. Kopplade senare på Xunit som test på vårt API

##### Azure Board Issues

Fortsatte med skapa issues för olika ärenden både administrativa dokument samt olika kod issues.

2020-09-16

Fortsatt arbete med issues. 

DB Context och models klara 

Skapat första migration & devops pipeline för Databasen

**SQLDatabas**

SQL Elastisk pool : nej

Basic

**Azure pipeline SQL YAML**

Tvungen skapa en subscripton mot Azure i Azure Devops







#### **2020-09-17**

Dagen började med att vi gav oss på att få till en koppling mellan vårat projekt med Entity Framework Core och SQL-databasen i Azure. Planen var även att vi skulle få till en första migration av databasen. För att få detta att fungera krävdes dock att några steg vidtogs innan:

**1. Ställa in brandväggen i azure för att släppa igenom oss som utvecklare**

För att man ska få prata med resurserna i ett azure-konto så behöver man släppas igenom resursens brandvägg. I detta fallet var det brandväggen till databasservern. För att släppa igenom en IP-adress så går man in på serverresursen, trycker på "Firewalls and virtual networks" i menyraden till höger och skapar därefter en ny regel för den IP man vill släppa igenom. Det kan vara förvirrande eftersom det står att man ska ange en "start-ip" och en "slut-ip". Vad detta innebär är att man kan ställa in regler för intervaller av IP-adresser. Det är framförallt bra att kunna göra i miljöer där man vet att man har ett gäng ip-adresser som går i serie för att kunna släppa in alla dem och inte behöva göra en regel för varje enskild adress (tänk om du har 1000 stycken!!). Vi har inte en sådan miljö utan vi lade till varje enskild adress. Då skriver man IP:et som både "start" och "slut".

**2. Se till att det finns en appsettings.json-fil i allas lokala projekt**

För att vår applikation ska veta vart den ska koppla upp sin Db-context mot så valde vi att lägga en connectionstring i filen med detta namn i vårt projekt. Detta är praxis i många projekt som använder sig av databaser. Proceduren är helt enkelt som sådan att man skapar en .json-fil rakt i sitt projekt i visual studio och döper den till "appsettings.json". Idenna läggs sedan denna koden in:

`{
  "ConnectionStrings": {
    "DefaultConnection": "\"Server=[servername];Initial Catalog=[Catalog];Persist Security Info=False;User ID=[UserId];Password=[Password];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}`

För att hitta rätt connection string till din azure-baserade sql-databas så går man in i databasresursen i sitt azure-konto. Därefter letar man upp databasservern bland sina resurser och går in på själva databasen. I menyn till höger finns ett manyalternativ som heter "Connection strings". Klickar du där så kan du se den och kopiera över den till din .json-fil.

**3. Att sagda .json-fil läggs till i .gitignore**

Eftersom man aldrig vill ha lösenord eller annan känslig information i sitt repository så är det viktigt att filer som innehåller sådan information inte spåras av det versionshanteringsverktyg man använder. Eftersom vi använder oss av git så lade vi till filen i den fil som heter ".gitignore". Allt som finns med i den filen ignoreras av git. Eftersom .gitignore filen också pushas upp i remote repot så innebär det att endast en person behöver lägga till vad som ska ignoras och sedan sprider det sig till övrig användare som hämtar ned den.

**SpaceParkAPI**

I API:t har vi idag gått vidare med att se till att Db-Contexten är hyfsat korrekt uppsatt samt att göra våra modeller, repositories och controllers färdigt (struktur enligt MVC-mönstret, fast utan v (view)). I grunden fungerar det som så, t.ex. för en get-request, att controllern får information om att användaren vill hämta något, skickar vidare förfrågan till repositoryt som letar och hämtar upp informationen från databasen, lagrar den i en modell av datan som är fördefinierad i applikationen, och passar den vidare till controllern som skickar den vidare till användaren. Men för att få detta att fungera helt enligt vårat mönster måste man också se till att startup-delen av vår applikation har lagt in våra repositories och controllers bland sina "services". För att se till att det finns där går man in i den fil som heter "startup.cs" och i metoden "ConfigureServices" lägger man till några bitar kod som just lägger till de delar den behöver känna till. Detta är också ett steg som är viktigt i det som kallas "Dependency Injection" som används i vår struktur. Du kan läsa mer om det här om du är nyfiken :

https://jakeydocs.readthedocs.io/en/latest/mvc/controllers/dependency-injection.html 

Nedan är ett exempel på hur det kan se ut:

`public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ISpaceshipRepo, SpaceshipRepo>();
            services.AddDbContext<SpaceParkContext>();
        } `

Vi har testat att göra requests lokalt och än så länge så fungerar saker och ting som tänkt.



Påbörjat controllers - Spaceship färdig (har läst på och konfigurerat dependency injection i startup för att det ska funka. Funkar lokalt med tom databas.).

Börjat fundera över om vi vill göra en migration varje gång som det stått i den tutorial vi följt för att sätta upp EF i pipelinen.

Manage Service Connections -> New -> Azure -> Fyll i och döp subscription till något.

**Vägval, vad använda för frontend.**
Diskussion om att först använda Razorsharp. Sett följande film för att bilda en uppfattning:
https://www.youtube.com/watch?v=68towqYcQlY

Efter övervägande, valde istället statiskt hemsida med javascript. Detta pga att det finns en viss lärokurva att lära sig Razorpages, och lite tid kvar till projektet, men även att vi redan kan javascript.

***kvällsuppdatering:** Har gjort en hel del research på att bygga en statisk hemsida med javascript i azure devops pipeline och få den att köra med webservices i azure. Har till slut lyckats. Tog mitt slutprojekt i Frontendkursen och experimenterade med. Dessutom lyckades jag trigga pipeline 2 (bygga image och skicka upp till ARC), efter att pipeline1 byggts. https://statichtmlcatalogue.azurewebsites.net/

Går även att deploya en statisk sida till en storage account - blob storage och visa som hemsida. Populärt då man inte behöver en backendserver i samma projekt. Ex visa en enkel landingpage eller ett mindre företag. Mycket billigare än en webservice.