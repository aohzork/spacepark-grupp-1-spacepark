# 02 Solution process - API

## API

För vår backend valde vi att göra ett .NET Core Api med olika calls via Controllers samt att vi använde oss av Entity Frameworks - Code First för vår databas, med vissa initialt seedade testdata.

Vi använde oss av Controllers, Models och Services (Repositoryies) men skippade DTO (Data Transfer Object). Vi tog beslut på att inte använda den då vi dels inte behövde dem samtidigt som huvudfokus för uppgiften låg på Azure och vi ville komma snabbare fram till just den delen i uppgiften. I vanliga fall hade vi haft med DTOs.

## Databas

Vi modellerade upp vår databas utefter vår databasdesign vi tog fram i samband med planeringen. Vår connectionstring lade vi i en appsettingsfil samt som tidigare nämnt samt att vi initialt seedade in lite data. Det första vi gjorde i vår API var att få igång databasen i Azure så vi hade den rullande. Vi kände att detta var ett viktigt moment att få till redan från start, så att vi inte satt och utvecklade hela vår backend för att i slutändan inte få vår databas i Azure att fungera. Vi valde SQL som databas i Azure.

## Connectionstring

Vår connectionstring hämtade vi i Azure efter vi skapat vår databas. Eftersom vi lade den i vår appsettings.json fick vi även sedan i Azure Portal skapa en keyvault som höll vår connectionstring som kopplade ihop våra andra resurser som också låg i Azure Portal (Frontend, API, SQL).

### KeyVault

Keyvault var lite lurigt att få till då det inte finns så mycket lättförståelig dokumentation på det. Men som tur var lyckades vi hitta ett youtubeklipp med en enkel lösning som var lätt att modifiera och implementera.

Följande länk hittas youtubeklippet: [[.Net Core] With Azure: Using Azure Key Vault to store Secrets](https://www.youtube.com/watch?v=yRf-doZMIBw)

Istället som för klippet, där implementationen av klassen han skapade låg i program.cs, använde vi den istället i vår SpaceParkContext där vår connectionstring till vår databas finns, samt att vi även försäkrade oss med en lokal fallback utifall vår secret slutade fungera av någon anledning:

![](D:\DOT.NET\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Solution\img\keyvault_implementation.PNG)

## Tester

Eftersom vi visste att tiden kunde bli knapp och vi samtidigt ville ha så mycket tid som möjligt för Azure Devops och  Azure Portal gjorde vi endast ett fåtal tester för att få med dem i vår pipeline. Vi använde oss av Xunit samt Mock(Moq nuget). Testerna skedde främst för våra Controllers där vi bland annat testade att vi fick tillbaka svarskod *Status200OK*, och objektet vi eftersökte.

## Utmaningar

Till en början gick det relativt långsamt eftersom vi var tvungna att få upp vår databas innan vi separerade och börja arbeta på våra egna issues. Vi hade lite även lite problem med vår connectionstring, vilket tog lite extra tid. Vid denna tid hade vi inte heller satt igång med vår Frontend och för att inte krocka och orsaka mergeconflicts blev resultatet vissa medlemmar stundvis fick avvakta i väntan på att olika issues (gjorda av andra teammedlemmar), skulle bli klara. En anledning är att vårt Backend API var såpass litet.

