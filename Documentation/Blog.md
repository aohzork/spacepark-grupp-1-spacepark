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

Manage Service Connections -> New -> Azure -> Fyll i och döp subscription till något.