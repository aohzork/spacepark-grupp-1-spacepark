# 02 Solution process - API

## API

För vår backend valde vi att göra ett .NET Core Api med olika calls via Controllers samt att vi använde oss av Entity Frameworks - Code First för vår databas, med vissa initialt seedade testdata.

Vi använde oss av Controllers, Models och Services (Repositoryies) men skippade DTO (Data Transfer Object). Vi tog beslut på att inte använda den då vi dels inte behövde dem samtidigt som huvudfokus för uppgiften låg på Azure och vi ville komma snabbare fram till just den delen i uppgiften. I vanliga fall hade vi haft med DTOs.

## Databas

Vi lade vår connectionstring i en appsettingsfil samt som tidigare nämnt, seedade in lite data. Det första vi gjorde i vår API var att få igång databasen i Azure så vi hade den rullande. Vi kände att detta var ett viktigt moment att få till redan från start, så att vi inte satt och utvecklade hela vår backend för att i slutändan inte få vår databas i Azure att fungera. Vi valde SQL som databas i Azure.

## Connectionstring

Vår connectionstring hämtade vi i Azure efter vi skapat vår databas. Eftersom vi lade den i vår appsettings.json fick vi även sedan i Azure Portal skapa en keyvault som höll vår connectionstring som kopplade ihop våra andra resurser som också låg i Azure Portal (Frontend, API, SQL).

## Tester

Eftersom vi visste att tiden kunde bli knapp och vi samtidigt ville ha så mycket tid som möjligt för Azure Devops och  Azure Portal gjorde vi endast ett fåtal tester för att få med dem i vår pipeline. Vi använde oss av Xunit samt Mock(Moq nuget). Testerna skedde främst på våra controllers där vi bland annat testade att vi fick tillbaka svarskod 200 OK, och vårt objekt som vi eftersökte.

## Utmaningar