# 04 Solution process - Azure Devops

## Att skapa CI Pipelines

Det går att skapa pipelines på två olika sätt. Classic editor utan ***.yml (YAML)***, där man steg för steg väljer in olika "***Agenter***" (motsvarighet till **Tasks** inne YAML-filen). Det nya sättet går snabbare att starta utan så många steg samt att en YAML fil skapas. YAML filen motsvarar Agenterna i Classic editor, fast med kod.

Du kan antingen låta YAML filen vara orörd och spara och köra igång pipelinen, vilket de flesta gör, eller så kan du  modifiera den innan du sparar (mer om detta senare), eller vid ett annat tillfälle. Det går dessutom lägga till fler Tasks som gör olika saker som exempelvis bygger en container åt dig.

För varje Task genereras ett litet kodstycke med olika parametrar och variabler, samt att du även kan modifiera **Settings** inuti varje Task.

### Vår lösning

För vårt projekt har vi skapat 3 pipelines:

1. En Build & Test-pipeline för vårt API
   2. Sammanlänkad pipeline som triggas efter Build & Test API har lyckats. Den sammanlänkade pipelinen skapar en Docker image som ladda upp  på  Azure Portal i en ACR (Azure Container Registy).


3. En pipeline som gör om vår Frontend (som består av statisk html med js) till en docker-image och pushar upp den till en ACR. I frontenden finns endast html- , css- samt js-filer.



## Modifiera pipelines

Som tidigare nämnt går det att modifiera sin pipeline och det gör man via .yml-filen i de fall man väljer det nyare sättet, där du lägger in tasks såväl som skriver egen kod samt även egna Variabler. Det går att göra det enkelt eller väldigt avancerat, varpå där det kan vara bra på ett större företag, med många produkter, komplexa krav mm.  att man har någon personal dedikerad enbart för Azure Devops samt Azure Portal.

### Variabler

[Define variables Microsoft Docs](https://docs.microsoft.com/sv-se/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#macro-syntax-variables)

Det går skapa variabler direkt i .yml filen eller via  knappen Variables, då du klickat Edit på din Pipeline. Via .yml filen ser det ut följande:

```
variables:
	hello: 'there'

steps:
- task: PublishBuildArtifacts@1`
	 name: $(hello)
```

Väljer man å andra sidan knappen Variables anger man istället ett namn och ett värde på variabeln i i två textrutor. Därefter går det även att bocka i **"*Keep this value secret*"**. Detta är bra i de fall, då man måste ange <u>Id/lösenord och eventuellt andra hemliga uppgifter direkt i filen</u>. Experimenterade en del med variabler för att försöka hitta en custom sökväg till en katalog, men det slutade med en annan lösning istället  (mer om detta i avsnittet *Bygga pipelines utefter olika kataloger...*).

## Trigga pipelines efter varandra

Det är fördelaktigt att ha flera pipelines mot samma repository, men som gör olika saker. Om inget annat anges, körs alla pipelines parallellt varje gång någon kod commitas mot master-repot (i vårt fall vårt Github-repo). Detta eftersom defaultvärde på samtliga pipelines **Trigger** är master:

*I .yml-filen för pipelinen*

```
trigger:
- master
```

Ibland är detta önskvärt, men problem uppstår dock då en viss pipeline måste köra klart innan en annan pipeline kan köra. I vårt fall vår **bygg och test-pipeline för vårt API**.

### Vår pipelinelösning för vårt projekt

Vi har totalt tre pipelines för vårt projekt som vi döpt följande för att lättare hålla reda på  dem:

**Pipeline Backend API Build + Tests** (pipeline 1)

**Pipeline Backend  API publish  Docker to ACR** (pipeline 2)

**Pipeline Frontend publish Docker to ARC** (pipeline 3)

![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/blob/master/Documentation/Solution/img/pipelines.PNG)

För att vårt projekt skulle laddas upp i ACR på Azure Portal valde vi följande steg:

1. Pipeline 1 som bygger vår Backend API lösning och kör automatiska tester
2. Pipeline 2 som bygger en Docker image av vår Backend API med **Tag: Build.buildnumber** och laddar upp i ett ACR. Men endast om Pipeline 1 lyckas
3. Pipeline 3 bygger en en Docker image av vår Frontend med Tag: Build.buildnumber och laddar upp till samma ARC som vår Backend image.

Genom att vi ville ha pipeline 2 frikopplad från pipeline 1 uppstod ett problem då båda pipelinesen körde parallellt oberoende om den ena pipelinen lyckades eller ej. Lösningen var att länka ihop pipelinesen genom att i .yml (för pipeline 2) trigga igång den andra pipelinen efter att första lyckats. En hel del research gjordes och slutligen hittades en lösning i följande dokumentation [Configure pipeline triggers - Azure Pipelines | Microsoft](https://docs.microsoft.com/en-us/azure/devops/pipelines/process/pipeline-triggers?view=azure-devops&tabs=yaml). Koden läggs under den kommenterade texten som finns överst i .ymlfilen.

*Översatt till lättare pseudokod som används i vår lösning samt ett tillägg:*
`Pipeline2.yml`

```
trigger:none

resources:
  pipelines:
	-pipeline: pipeline1-hitta-på-namn   # Name of the pipeline resource
	source: Pipeline1 # Name of the pipeline referenced by the pipeline resource
	trigger: 
  		branches:
		-master
```

<u>*Trigger: none*</u> är tillägget som gör att pipeline2 endast triggas efter pipeline 1 har passerat OK. Utan detta tillägg, körde Pipeline2 ändå samtidigt som Pipeline1 av någon anledning.

Vad som händer sedan är att pipeline1 körs, som triggas av master. Därefter fortsätter Steps och Tasks precis som vanligt i Pipeline2.yml.

## Artifacts

När vi pratar Release Pipeline och artifacts pratar vi om distribuerbara komponenter. Exempelvis produceras en artifact som slutprodukt av en vanlig pipeline.  I vårt fall är våra release artifacts våra image-filer som producerades av våra pipelines, som laddades upp till en ACR.

## Release Pipeline

![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/blob/master/Documentation/Solution/img/releasepipeline_frontend.PNG)

För vår lösning använder vi oss av **två fristående Release pipelines**; en för vårt <u>API</u> samt en för vår <u>Frontend</u>. Vi använder oss av en **artifact** för varje, där slutmålet är att göra en deploy till var sin **App Service** i **Azure Portal**. Varje artifact pekar/är kopplad mot en image i Azure Portal.

När de båda pipelinesen körs igång, hämtas den senaste versionen av respektive image ner till artifactsen. Därefter skickas de vidare och kopplas ihop med våra App Services, vilket gör att det publikt går att komma åt dem via deras dns.

Release pipelinesen är inställda på automatisk release då det sker en förändring i våra vanliga pipelines, ergo; det laddas upp en ny image-version i ARC.

## Utmaningar

Vilket sätt är rätt? Det finns nog inget svar på detta eftersom att det går att göra på flera olika sätt och möjligheten hur man kombinerar dessa sätt är oändliga. Vissa väljer att lägga in massvis med kod och kör allt i sin .yml fil. Andra föredrar classic pipeline och jobba agenter och via det visuella gränssnittet. Skall man bygga flera olika pipelines eller en enda lång? Det är inte konstigt om det skulle finnas personer som endast sitter med Azure Devops på heltid. Den största utmaningen var att förstå hur allt hänger ihop. Att du kan bygga ut en .yml-fil (efter du skapat den), med massa olika steps och tasks. Du kan även länka in config-filer och flera andra typer av filer som du anger i .yml-filen. Det hjälpte att ha egna testprojekt vid sidan om huvudprojektet där det gick att sitta och experimentera sig fram vad olika tasks och variabler gjorde.

Vad gäller Release-pipelinen är det samma där. Du kan kombinera olika agenter, steps och tasks som i slutändan resulterar i en enda release. Kombinationerna även där är oändliga.

Boards var ett bra verktyg med subtasks som visades tydligt samt att det var bra att samla så  mycket som möjligt på ett enda ställe. Samtidigt kanske du ha din kanban fristående alla olika Devops-system.

Hur du väljer att publicera din applikation(er) via devops är en svår fråga. Det går nog inte att hitta ett enda optimalt sätt. utan det är helt beroende på dina behov, din budget, din applikation och slutligen din kreativitet och subjektivitet.

