# 05 Solution process - Azure Portal

![](D:\DOT.NET\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Solution\img\ap_resourcegroup.PNG)

Tjänsterna i Azure Portal var lätta att sätta upp och det gjorde inget om man gjorde fel; det var bara att radera tjänsten och börja om på  nytt. Med hjälp av de tidigare övningarna i föregående kurslektioner, visste vi på ett ungefär vad vi behövde för tjänster och hur vi skulle konfigurera upp dem. Bilden  ovan illustrerar de namn som nämns genom hela avsnittet för att lättare följa med.

## ACR (Azure Container Registry)

I vår ACR *(SwAPIConerRegistry)* pushas båda våra image *(frontend och backend api)* upp från våra vanliga pipelines. Därefter hämtas respektive image via realease pipeline och läggs in i respektive App Service.

**FrontendWebSw** för vår frontend. **WebAPIBackendSW** för vår backend.

## Val av webhosting

För både backend och  frontend valde vi App Service och valet grundade sig på att vi visste att det fungerade, hade dessutom gjort research och test tidigare på vår frontend som visade att även en vanligt HTML-sida med javascript fungerade. Dessutom tog App Service container-images.

Det finns några andra alternativ för en simpel frontendhemsida. Bland annat skall  det gå att skapa upp en sådan via ett Blobstorage, vilket skall vara  mycket billigare. Dock hade vi inte hunnit prova detta alternativt, utan endast läst om det i artiklar, så vi lät det vara.

 Vill man vara kostnadseffektiv så kan det löna sig att titta på andra alternativ än App Service. Dock bör man vara medveten om vilka features som följer med de olika alternativen.

### Kostnadsjämförelser

Oavsett vilken typ Webhosting tjänst man väljer kostar det olika mycket beroende på vad för typ av konfiguration man väljer samt olika tillägg.

För vår App Service finns det flera olika Tiers och vi valde ett gratisalternativ då vi inte visste hur länge våra gratiskrediter skulle vara. Det finns även en uppgradering för ett kostnadsalternativ för denna tier.

![](D:\DOT.NET\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Solution\img\appservice_servicecost_devtier.PNG)

Av vad man kunnat läsa sig till i olika artiklar rekommenderas dessa främst för utveckling och testning, men även om man exempelvis är ett uppstartsbolag eller bara  har en enkel hemsida. För gratisalternativet **60 minuter/dag** menas inte att hemsidan är online 60 min/dag, utan snarare den tid det tar när data hämtas. Om du då surfar in på en hemsida där bilder och annat tar säg 5sekunder att ladda, då är det 5sekunder av de 60minuter du har tillgodo.

Flyttar vi däremot upp en Tier Produktion, såsom sig bör om du har en någorlunda avancerad hemsida och etablerat företag kommer vi upp i helt andra kostnader men man får samtidigt mer prestanda samt olika tjänster som ingår:

![](D:\DOT.NET\Molntjänster\Projekt\spacepark-grupp-1-spacepark\Documentation\Solution\img\appservice_servicecost_productiontier.PNG)

Det går lätt att skala upp och ner i prestandan. Du väljer och trycker på använd, så har du bytt och dina krediter börjar direkt räknas utefter det nya valda alternativet.

Val av databas

Utmaningar