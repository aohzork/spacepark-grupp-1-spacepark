# 04 Solution process - Azure Devops

## Att skapa CI Pipelines

Det går att skapa pipelines på två olika sätt. Classic editor utan ***.yml (YAML)***, där man steg för steg väljer in olika "***Agenter***" (motsvarighet till **Tasks** inne YAML-filen). Det nya sättet går snabbare att starta utan så många steg samt att en YAML fil skapas. YAML filen motsvarar Agenterna i Classic editor, fast med kod.

Du kan antingen låta YAML filen vara orörd och spara och köra igång pipelinen, vilket de flesta gör, eller så kan du  modifiera den innan du sparar (mer om detta senare), eller vid ett annat tillfälle. Det går dessutom lägga till fler Tasks som gör olika saker som exempelvis bygger en container åt dig.

För varje Task genereras ett litet kodstycke med olika parametrar och variabler, samt att du även kan modifiera **Settings** inuti varje Task.

### Vår lösning

För vårt projekt har vi skapat 3 pipelines:

1. En Build & Test-pipeline för vårt API
   2. Sammanlänkad pipeline som triggas efter Build & Test API har lyckats. Den sammanlänkade pipelinen skapar en Docker image som ladda upp  på  Azure Portal i en ACR (Azure Container Instance).


3. En pipeline som bygger vårt Frontend som består av statisk html med js. I frontenden finns endast html- , css- samt js-filer.



## Modifiera pipelines

Som tidigare nämnt går det att modifiera sin pipeline och det gör man via .yml-filen i de fall man väljer det nyare sättet, där du lägger in tasks såväl som skriver egen kod samt även egna Variabler. Det går att göra det enkelt eller väldigt avancerat, varpå där det kan vara bra på ett större företag, med många produkter, komplexa krav mm.  att man har någon personal dedikerad enbart för Azure Devops samt Azure Portal.

### Variabler

[Define variables Microsoft Docs](https://docs.microsoft.com/sv-se/azure/devops/pipelines/process/variables?view=azure-devops&tabs=yaml%2Cbatch#macro-syntax-variables)

Det går skapa variabler direkt i .yml filen eller via  knappen Variables, då du klickat Edit på din Pipeline. Via .yml filen ser det ut följande:

```
variables:`
	hello: 'there'`

`steps:`

`- task: PublishBuildArtifacts@1`
	 name: $(hello)
```

Väljer man å andra sidan knappen Variables anger man istället ett namn och ett värde på variabeln i i två textrutor. Därefter går det även att bocka i **"*Keep this value secret*"**. Detta är bra i de fall, då man måste ange <u>Id/lösenord och eventuellt andra hemliga uppgifter direkt i filen</u>. Experimenterade en del med variabler för att försöka hitta en custom sökväg till en katalog, men det slutade med en annan lösning istället  (mer om detta i avsnittet *Bygga pipelines utefter olika kataloger...*).

## Trigga pipelines efter varandra

## Bygga pipelines utefter olika kataloger i Github-repo

## Artifacts

## Release Pipeline

## Utmaningar