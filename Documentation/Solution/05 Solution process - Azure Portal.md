# 05 Solution process - Azure Portal

![ap_resoursegroup](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/tree/master/Documentation/Solution/img/ap_resourcegroup.PNG)

Tjänsterna i Azure Portal var lätta att sätta upp och det gjorde inget om man gjorde fel; det var bara att radera tjänsten och börja om på  nytt. Med hjälp av de tidigare övningarna i föregående kurslektioner, visste vi på ett ungefär vad vi behövde för tjänster och hur vi skulle konfigurera upp dem. Bilden  ovan illustrerar de namn som nämns genom hela avsnittet för att lättare följa med.

## ACR (Azure Container Registry)

I vår ACR *(SwAPIConerRegistry)* pushas båda våra image *(frontend och backend api)* upp från våra vanliga pipelines. Därefter hämtas respektive image via realease pipeline och läggs in i respektive App Service.

**FrontendWebSw** för vår frontend. **WebAPIBackendSW** för vår backend.

## Val av webhosting

För både backend och  frontend valde vi App Service och valet grundade sig på att vi visste att det fungerade, hade dessutom gjort research och test tidigare på vår frontend som visade att även en vanligt HTML-sida med javascript fungerade. Dessutom tog App Service container-images.

Det finns några andra alternativ för en simpel frontendhemsida. Bland annat skall  det gå att skapa upp en sådan via ett Blobstorage, vilket skall vara  mycket billigare. Dock hade vi inte hunnit prova detta alternativt, utan endast läst om det i artiklar, så vi lät det vara.

 Vill man vara kostnadseffektiv så kan det löna sig att titta på andra alternativ än App Service. Dock bör man vara medveten om vilka features som följer med de olika alternativen.

### Frontend

Såhär ser vår frontend ut i azure:
![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/tree/master/Documentation/Solution/img/ap_frontend.PNG)

### Backend

Såhär ser vår backend ut i azure:

![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/tree/master/Documentation/Solution/img/ap_backend.PNG)



## Val av databas

Vi valde en SQL server eftersom den mappade bra mot Entity Frameworks. Databasen fixade vi som tidigare nämnt i Solution Process - API, ville vi ha databasen uppe och snurrande redan från start så att vi visste att det fungerade. Vi valde **Tier Basic**. Denna kommer med en storlek på 2GB samt 5st DTU:er. Mer om DTU:er och lagringskapacitet och begränsningar i [denna artikeln](https://docs.microsoft.com/sv-se/azure/azure-sql/database/service-tiers-dtu#elastic-pool-edtu-storage-and-pooled-database-limits).

Databasen fungerar bra för den som endast behöver en databas utan några speciella krav för att lagra information. Du kan när som helst skala upp databasen till nästa Tier (Standard).

Med Elastiskt skalning får du mer lagringsutrymme till en viss gräns.  Dock kostar detta mer. Olika standardinställningar följer med såsom Business Intelligence, Frågeredigerare, Geo-replikering (duplicering av databaser till andra regioner) med mera.



## Kostnadsjämförelser

I detta avsnitt visas lite olika kostnadsjämförelser mellan olika tjänster och kostnadsnivåer (Tiers) inom samma tjänst.

### Webhosting

Oavsett vilken typ Webhosting tjänst man väljer kostar det olika mycket beroende på vad för typ av konfiguration man väljer samt olika tillägg.

#### App Service

För vår App Service finns det flera olika Tiers och vi valde ett gratisalternativ då vi inte visste hur länge våra gratiskrediter skulle vara. Det finns även en uppgradering för ett kostnadsalternativ för denna tier.

![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/tree/master/Documentation/Solution/img/appservice_servicecost_devtier.PNG)

Av vad man kunnat läsa sig till i olika artiklar rekommenderas dessa främst för utveckling och testning, men även om man exempelvis är ett uppstartsbolag eller bara  har en enkel hemsida. För gratisalternativet **60 minuter/dag** menas inte att hemsidan är online 60 min/dag, utan snarare den tid det tar när data hämtas. Om du då surfar in på en hemsida där bilder och annat tar säg 5sekunder att ladda, då är det 5sekunder av de 60minuter du har tillgodo.

Flyttar vi däremot upp en Tier Produktion, såsom sig bör om du har en någorlunda avancerad hemsida och etablerat företag kommer vi upp i helt andra kostnader men man får samtidigt mer prestanda samt olika tjänster som ingår:

![](https://github.com/PGBSNH19/spacepark-grupp-1-spacepark/tree/master/Documentation/Solution/img/appservice_servicecost_productiontier.PNG)

Det går lätt att skala upp och ner i prestandan. Du väljer och trycker på använd, så har du bytt och dina krediter börjar direkt räknas utefter det nya valda alternativet.

#### Blob storage

För en hemsida i en Blob storage lågfrekvent aktivitet, minskat utrymme till 2GB istället för 1TB är kostnaden per månad ca  **12 USD**.

### Databas

#### DTU-baserade alternativ

| Tier     | Lagring GB | Standard DTU | Pris/mån SEK | Max DTU | Max Lagring GB | Pris/mån SEK |
| -------- | ---------- | ------------ | ------------ | ------- | -------------- | ------------ |
| Basic    | 2          | 5            | 43,61        | 5       | 2              | 43,61        |
| Standard | 250        | 10           | 131,06       | 3000    | 1000           | 41144,18     |
| Premium  | 500        | 125          | 4560,25      | 4000    | 4096           | 156980,98    |

#### Virtuella kärnor

Det går även att välja databaser med virtuella kärnor; både som etablerad och serverlös. En stor faktor som skiljer mellan etablerad kontra serverlös databas är att etablerade databaser kostnadsberäknas per timma medan serverlösa beräknas per sekund. En annan viktig skillnad är att det går att stoppa serverlösa databaser när de inte används såsom det går med andra tjänster som exempelvis en ACI (Azure Container Instance).

Likväl här finns olika tiers; **Allmän, Storskalig och Verksamhetskritisk**. Lägsta kostnaden för Allmän är ca 3319 SEK. Storskalig ca 5440 SEK och Verksamhetskritisk ca 4620 SEK. Med konfigurationer på höga krav på databasen kommer priset öka drastiskt.



## Utmaningar

Till större delen gick Azure Portal ganska smidigt, men innan  vi kom fram till vår slutgiltiga lösning gjorde vi en del tester i form av att skapa upp olika tjänster för att exempelvis se att det gick att placera ett HTML projekt i en webservice osv.

Efter en refaktorering av databasen blev det en del fel på vår befintliga SQL-databas i Azure, så vi var tvungna att ta bort den och lägga till en ny. Som tur var, blev det samma connectionstring och lösenord eftersom databasen endast togs bort, ej databas-servern som wrappar databasen.

Vi försökte oss som tidigare beskrivet i Backendavsnittet på oss på Key Vault. Tanken är god, men implementeringen var svår, då det verkar finns många olika krångliga lösningar på det. Eller att att vissa är utdaterade mot hur det ser ut och fungerar i Azure. Med mer tid kanske vi hade hittat en lösning.
