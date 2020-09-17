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



**Se till att vi hade rätt autentisieringsuppgifter**

En av nycklarna i allt detta, som tog oss lite tid att förstå, var att vi behövde rätt uppgifter från azure för att få koppla upp oss. (Micael, fyll på här!)



**Ställa in brandväggen i azure för att släppa igenom oss som utvecklare**

För att man ska få prata med resurserna i ett azure-konto så behöver man släppas igenom resursens brandvägg. I detta fallet var det brandväggen till databasservern. För att släppa igenom en IP-adress så går man in på serverresursen, trycker på "Firewalls and virtual networks" i menyraden till höger och skapar därefter en ny regel för den IP man vill släppa igenom. Det kan vara förvirrande eftersom det står att man ska ange en "start-ip" och en "slut-ip". Vad detta innebär är att man kan ställa in regler för intervaller av IP-adresser. Det är framförallt bra att kunna göra i miljöer där man vet att man har ett gäng ip-adresser som går i serie för att kunna släppa in alla dem och inte behöva göra en regel för varje enskild adress (tänk om du har 1000 stycken!!). Vi har inte en sådan miljö utan vi lade till varje enskild adress. Då skriver man IP:et som både "start" och "slut".



**Se till att det finns en appsettings.json-fil i allas lokala projekt**

För att vår applikation ska veta vart den ska koppla upp sin Db-context mot så valde vi att lägga en connectionstring i filen med detta namn i vårt projekt. Detta är praxis i många projekt som använder sig av databaser. Proceduren är helt enkelt som sådan att man skapar en .json-fil rakt i sitt projekt i visual studio och döper den till "appsettings.json". Idenna läggs sedan denna koden in:

`{
  "ConnectionStrings": {
    "DefaultConnection": "\"Server=[servername];Initial Catalog=[Catalog];Persist Security Info=False;User ID=[UserId];Password=[Password];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}`

För att hitta rätt connection string till din azure-baserade sql-databas så går man in i databasresursen i sitt azure-konto. Därefter letar man upp databasservern bland sina resurser och går in på själva databasen. I menyn till höger finns ett manyalternativ som heter "Connection strings". Klickar du där så kan du se den och kopiera över den till din .json-fil.



**Att sagda .json-fil läggs till i .gitignore**

Eftersom man aldrig vill ha lösenord eller annan känslig information i sitt repository så är det viktigt att filer som innehåller sådan information inte spåras av det versionshanteringsverktyg man använder. Eftersom vi använder oss av git så lade vi till filen i den fil som heter ".gitignore". Allt som finns med i den filen ignoreras av git. Eftersom .gitignore filen också pushas upp i remote repot så innebär det att endast en person behöver lägga till vad som ska ignoras och sedan sprider det sig till övrig användare som hämtar ned den.









Gjort en första migration.

Fixat till connection string (hittades i azure-portalen).

<u>Tillåtit alla användare i brandväggen.</u>

<u>Fixat till appsettings.json.</u>

<u>Fixat till .gitignore.</u>

Påbörjat controllers - Spaceship färdig (har läst på och konfigurerat dependency injection i startup för att det ska funka. Funkar lokalt med tom databas.).

Gjort klart spaceship models/repo/controller.

Sett till att context, startup och models är korrekta so far.

Börjat fundera över om vi vill göra en migration varje gång som det stått i den tutorial vi följt för att sätta upp EF i pipelinen.

<u>Manage Service Connections -> New -> Azure -> Fyll i och döp subscription till något.</u>

Vägval, vad använda för frontend.
Diskussion om att först använda Razorsharp. Sett följande film för att bilda en uppfattning:
https://www.youtube.com/watch?v=68towqYcQlY

Efter övervägande, valde istället statiskt hemsida med javascript. Detta pga att det finns en viss lärokurva att lära sig Razorpages, och lite tid kvar till projektet, men även att vi redan kan javascript.

