# 01 Solution process - Planering och förberedelser

Som vanligt när man genomför ett projekt så behöver planer och strukturer revideras under tidens gång. Vi tycker att vi ändå lyckats parera och ackommodera de förändringar vi behövt göra på ett rätt så bra sätt och förändringar i grundplaneringen har inte orsakat något av de större utmaningarna eller problemen. Men med det sagt så kan man ju alltid planera mera.

## Databas

Detta var en av de första sakerna vi började planera. Tanken var att vi skulle ha en hierarkiskt uppbyggd relationsdatabas med ett till ett förhållanden mellan person, rymdskepp och parkeringsficka. Längst upp i hierarkin hade vi parkeringsplats med ett ett till många förhållande till parkeringsficka.

Vi satte kanske inte helt databasens struktur efter vår tanke helt från början och har fått revidera strukturen under projektets gång. Det innebar att modellerna behövde göras om och databasen behövdes tas bort för att kunna föra in de nya uppdateringarna. Det tog inte överdrivet mycket tid att fixa till det men lite mer planering i början hade kanske gjort att det inte hade behövts. I slutändan så har vi fått till en struktur vi är rätt nöjda med. Vi hade dock inte tagit med i beräkningen att code-first set-upen i modellerna skulle leda till rekursion i hämtningen av datan. Detta löstes genom att hårdkodat mappa om modellerna innan datan skickades ut. Inte den bästa av lösningar och givet mer tid så hade vi kanske övervägt att använda DTO:er eller liknande istället. Men det fungerar och för detta projekt är det gott nog.



*Första iterationen av databasdiagrammet*

![DBDesign_rev1](C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\DBDesign_rev1.PNG)

*Andra iterationen av databasdiagrammet*

![DBDesign_rev2](C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\DBDesign_rev2.PNG)





## Arbetsregler

För att alla skulle vara överens om hur man arbetar i projektet skapades olika dokument med överenskommelser kring hur det ska ske. Såklart följs inte allting till punkt och pricka och det måste finnas flexibilitet i arbetet. Men bara att ha skapat dokumenten och pratat om det gör att man kan ha en gemensam förståelse för hur alla tänker och förhåller sig till projektet.

För att kunna hålla koll på alla kriterier och regler för projektet gjordes en sammanfattning av projektinstruktionerna. Tanken var att vi då inte skulle missa några element som måste implementeras i vår lösning. 

[Projektsammanfattning]: C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Projectoutlineandrules.md

Vi gjorde ett arbetsschema som talade om löst vilka tider på dagen som det är tänkt att man arbetar, hur vi gör med dokumentering av arbetet och hur vi gör med code reviews. Detta schema följdes inte strikt, vilket heller inte var tanken, men det gav en gemensam förståelse för alla hur var och en tänker. 

[Arbetsschema]: C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Arbetsschema.md

För att gemensamt komma överens om hur vi skulle hantera git-flödet gjordes även ett dokument för detta. Däri finns några enkla stolpar som talar om för alla hur det ska gå till. Det finns även ett diagram som illustrerar processen. 

[Git-Flöde]: C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\GitWorkflowRules.md



## Stand-Ups och Kanban

Under projektets gång har vi använt oss av stand-ups så gott som varje dag för att få en överblick kring vart vi ligger till i projektet och för att veta vad var och en ska göra för dagen, men även om det är så att någon är frånvarande under någon gång.

[Stand-Ups]: C:\Users\hampe\Repos\Skola\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Stand-Up.md



Som förberedelse så satte vi även upp issues inför starten på projektet så vi hade en utgångspunkt. Vi valde att göra detta i Azure DevOps för att testa på deras lösning. Vi valde att använda oss av deras Kanban-board och det har fungerat bra. Inte lika avancerat som en sprint kanske  men det räckte gott och väl för vår grupp och har gett oss en bra överblick under projektets gång. 



## Blog	

Bloggen användes till en början men har senare övergivits. Punkter har lagts till då och då för att ha som hjälp till när denna slutdokumentation skulle göras men överlag så kände vi att bloggen inte tillförde något värde i vår process. Det finns dock dokumentation som gjorts när något har varit viktigt nog att dokumentera under projektets gång (till exempel CORS-dokumentationen).



**********RÄTTA TILL OCH BAKA IN DENNA TEXT SÅ GOTT DET GÅR ******

# 01 Solution process - Planering och förberedelser

Att ge sig tid åt planering och förberedelser inför ett projekt är en konst. Speciellt som utvecklare då det kliar i fingrarna att sätta igång och koda så snabbt som möjligt. Inför detta projeket mot flera tidigare projekt i andra kurser försökte vi ägna extra mycket åt planeringen innan det var dags att sätta igång.

​	

## Boards och Issues

![](D:\DOT.NET\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Solution\img\devops-boards.PNG)

Vi började med *Jira* och *Sprintar* eftersom vi hade erfarenhet av det tidigare. Men kort därefter migrerade vi till *Devops Boards* som istället använde Kanban, vilket gick ganska så smidigt. Den stora fördelen var att ha så mycket som möjligt samlat på ett ställe samt att vi kände att det kunde vara roligt att lära sig något nytt. Vissa delar ur Devops Boards var lättare och tydligare såsom SubTasks till ett Issue/Task. Andra delar var lite otydligare, såsom datum-märkning av klara Issues.  Detta var Jira överlägsen att på ett tydligt sätt visa.

Det finns som sagt fördelar och nackdelar vilken typ av system man använder. Det går även att argumentera eventuellt inlåsningseffekt om man använder Devops Boards, mot Jira, utifall man i ett projekt skulle byta Devops-system. Då är det bättre att ha de olika systemen frikopplade.

I förberedelsefasen skapade vi upp grundläggande specifika issues på olika moment vi behövde få klart tidigt såsom **EF Core**, Migrera  datasen till Azure i ett tidigt skede osv. Andra mer generella issues skapades också för att inte glömma av som exempelvis **Skapa Frontend** eller **Skriva dokumentation**. Desto längre in i projektet vi kom, desto konkretiserades dessa issues.



## Regler

Det är viktigt i ett projekt att alla medlemmar är överens om vad som gäller, och vi alla gick in i projektgruppen med olika erfarenheter från tidigare projekt och projektgruppskonstellationer från tidigare kurser. Vi diskuterade olika regler och kom överens eller kompromissade och i de fall vi tyckte allt för olika så röstade vi. I stort skulle man kunna säga att vi kombinerade olika regler och kunskap som medlemmarna samlat på sig från tidigare projekt som däri fungerat bra. Saker som inte fungerat lika bra i de olika grupperna drog vi erfarenhet av och försökte att inte göra om i denna gruppen.

### Tider

De dagar vi inte haft lektion har vi suttit från klockan 09-16 ibland 16.30. Har medlemmar behövt göra ärenden och  vara frånvarande vissa tider/dagar så har detta inte varit något problem så länge medlemmen meddelat det till gruppen. Vi lever alla olika liv där vi försöker lösa livspusslet på bästa sätt. Precis som på en vanlig arbetsplats.

### Standups 

Vi böjar med standups och berättar läget. Går igenom saker på dagordningen. Stänger och  skapar nya issues, går igenom pullrequests och mergar branches. Frågor, funderingar, vissa delar inom projektet som vi behöver gås igenom gemensamt eller om någon vill dela skärm i Discord och visa något speciellt.

Vi har inte haft någon speciell ordning på vem som håller i standupsen, men har ändå turats om.

### Github

- *<u>Branches</u>* - Material som skall upp i repot (exempelvis olika dokument/bilder mm) som inte innefattar kod finns det inget krav på att skapa en branch, utan kan pushas upp direkt i master. Dock gjorde vi en issue i Devops Boards för det, för att inte glömma av.

- <u>*Pullrequests*</u> - Eftersom alla kanske inte är online samtidigt bestämde vi att en pullrequest behöver åtminstone 2 approvals innan man får göra en merge mot master.

- <u>*Spontana pullrequests*</u> - Utifall det uppkommit pullrequests som behövdes mergas under dagen, som inte fanns med under standupsen, så går det att merga dessa kontinuerligt, så länge de fått 2 approvals.

- <u>*Kritiska pullrequests*</u> - Ibland behövde viss kod pushas in direkt i master, av olika anledning utan att hinna få några approvals. Dessa gick att merga in, sålänge resterande medlemmar i gruppen tyckte att det gick bra. Ett exempel kan vara att installera en viss Nuget som samtliga medlemmar i projektet var beroende av i sina branches

  

## Planeringsdokument

Databasdesign

Revidering av databasdesign

Flowchart

## Praktiska förberedelser av Repo innan start