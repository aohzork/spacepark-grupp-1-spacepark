# 03 Solution process - Frontend

Vår frontend är den som visar upp hemsidan där man väljer att parkera. Vi valde att ha en del av vår affärslogik i den och använda vår backend som ett API som vi utför CRUD-anrop till via vår frontend.

## Val av typ av frontend

När vi hade kommit en bit på vår backend, påbörjade vi vår frontend. Vi diskuterade de olika val vi hade att välja på; MVC, Razorpages, HTML/js/jquery.

Tankarna  bakom var att vi snabbt ville komma igång och snabbt få gjort Frontenden. De mest populära valen stod mellan Razorpages och en vanlig HTML-sida med  javascript och jquery. Till slut föll valet på att vi röstade om en lösning. HTML-sidan vann. Anledningen är att ingen av oss kunde Razorpages sedan tidigare, även om vi ville lära oss det. Därför tänkte vi att vi behövde lägga onödig lärotid på att lära oss Razorpages,  medan med en HTML-sida som läser/skriver från olika API, så hade vi redan gjort en sådan i vår Frontendkurs, vilket skulle snabba på vår utveckling.

## Affärslogik

Den affärslogik som ligger på frontendsida administrerar anropen som behöver göras för att en användare ska kunna använda parkeringsfunktionen. Exempel på anrop kan hittas i den fil som heter "BackendApiCalls.js" (kodexempel återfinns i botten av detta avsnitt). Helt enkelt konstrueras ett "promise" (löfte) som man sedan kan använda sig av för att anropa CRUD-operationerna i API:t. När löftena körs och blir klara så är tanken att de ska mappa om resultatet och returnera ett fördefinierat objekt (objekten återfinns i filen "Models.js") som man sedan kan använda sig av för fortsatt hantering. Tanken var att det skulle vara lättare för programmeraren att hantera ett rymdskepp, en person eller en parkeringsplats snarare än att hantera rå json-data. 

Om-mappningen till objekt är inte fullt implementerad ännu i vår lösning då vi fick tidsbrist.

På samma sätt finns det metoder i de fördefinierade  objekten som kan omvandla en rå json-sträng till objekt. Dessa metoder hade behövt ha lite mer kött på sig för att fungera exakt som önskat, men de gör sitt jobb för stunden även om de är lite småfarliga att använda (det den gör är att omvandla vad den än fått in till ett objekt, som sagt... lite småfarligt). Resultatet av detta ska sedan gå att använda när man vill skicka en post-request till api:t och man kan då använda resultatet av metoden som body.

Det finns även metoder för att anropa web-api:t "swapi.dev". Dessa är till för att kontrollera att den person som vill parkera finns med i swapi (och därmed är en del av star wars). De görs på ett liknande sätt som anropen mot vårt egna api.



```javascript
const getPerson = async (name) => {
    try {
        let response = await fetch(`https://localhost:44350/api/v1.0/person/${name}`,
            { method: 'GET' });
        let data = await response.json();

        console.log(response);

        let obj = new Person();
        obj = obj.MapFromJson(JSON.stringify(data));
        return obj;
    } catch (error) {
        console.error(error);
    }
};
```

*Exempel 1: Get-metod i Frontend*



```javascript
//Method making a call to our api to post a person by name.
const postPerson = async (personObject) => {
    try {

        //Do request
        let response = await fetch(`https://localhost:44350/api/v1.0/person`,
            {
                method: 'POST',
                headers: { 'Content-Type': `application/json` },
                body: personObject.ToJsonString()
            });

        //Log the response to console
        console.log(response);

        //Get the response body as json and return it
        let json = response.json();
        return json;
    } catch (error) {
        console.error(error);
    }
};
```

*Exempel 2: Post-metod i Frontend*



```javascript
class Person {
    constructor(){
        this.ID = "";
        this.Name = "";
    }

    ToJsonString() {
        return JSON.stringify(this);
    }

    MapFromJson(jsonString) {
        let myMap = JSON.parse(jsonString);        
        let obj = new Person();

        obj = myMap;

        return obj;        
    }
}
```

*Exempel 3: Objekt-klass i Frontend*



```javascript
function getStarShipsFromSwapi(input) {
    let url = `https://swapi.dev/api/people/?search=${input}`
    let request = new XMLHttpRequest();
    request.open("GET", url);
    request.onload = function () {
        let data = JSON.parse(request.responseText);

        try {
            let starShips = [data.results[0].starships];
            fetchShips(starShips);
            document.getElementById("errorMessage").innerHTML = "";
        }
        catch (error) {
            document.getElementById("errorMessage").innerHTML = input + ": " + "Are not allowed to use SpacePark";
        }
    }
    request.send();
}
```

*Exempel 4: swapi.dev-anrop i Frontend*



## Presentationslogik

ERIC OCH AMDREAS FYLL PÅ HÄR

## Metoder



## Utmaningar

Vi stötte på flera utmaningar som vi inte räknade med när vi utvecklade vårt Frontend, som vi förmodligen hade sluppit om vi istället använt Razorpages.

Att göra POST-requests från vår Frontend mot API:t var lite av en utmaning då CORS (Cross Origin Resource Sharing) satte stopp för det. Efter att ha läst på mer om det så förstod vi att för att skicka data i json-format via CORS så innebär det att det blir en "komplicerad" request (till skillnad från en "simpel" request). Det innebar att vi var tvugna att lägga till en header i anropet från Frontenden och att vi tillät den headern i API:t. Det går att läsa mer om detta i vår CORS-dokumentation.

En annan utmaning var även att arbeta med asynchrona anrop i javascript. Vid en punkt under projektet slutade det helt fungera för en av oss av oförklarlig anledning (det funkade samtidigt för oss andra) samt att det tog lite tid att sätta sig in i hur den typen av anrop fungerar i javascript. Ett annat problem som stammade ur detta var också hur man väl använde resultatet av anropet när man väl gjort det (ett löfte returnerades istället för json-datan etc.). Vi fick till slut bukt på det men har nog fortfarande mer att lära. 

