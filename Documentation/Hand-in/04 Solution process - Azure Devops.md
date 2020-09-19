# 04 Solution process - Azure Devops

Boards och Issues

Att skapa CI Pipelines

Det går att skapa pipelines på två olika sätt. Classic editor utan .yml (YAML), där man steg för steg väljer in olika "***Agenter***" (motsvarighet till **Tasks** inne YAML-filen). Det nya sättet går snabbare att starta utan så många steg samt att en YAML fil skapas. YAML filen motsvarar Agenterna i Classic editor, fast med kod.

Du kan antingen låta YAML filen vara orörd och spara och köra igång pipelinen, vilket de flesta gör, eller så kan du  modifiera den innan du sparar (mer om detta senare) eller vid ett annat tillfälle. Det går dessutom lägga till fler Tasks som gör olika saker som exempelvis bygger en container åt dig.

För varje Task genereras ett litet kodstycke med olika parametrar och variabler, samt att du även kan modifiera settings inuti varje Task.

För vårt projekt har vi skapat 3 pipelines.

1. En Build & Test-pipeline för vårt API
   2. Sammanlänkad pipeline som triggas efter Build & Test API har lyckats. Den sammanlänkade pipelinen skapar en Docker image som ladda upp  på  Azure Portal i en ACR (Azure Container Instance).

3. En pipeline som bygger vårt Frontend som består av statisk html med js. I frontenden finns endast html- , css- samt js-filer.



Modifiera pipelines

Trigga pipelines efter varandra

Bygga pipelines  utefter olika kataloger i Github-repo

Artifacts

Release Pipeline

