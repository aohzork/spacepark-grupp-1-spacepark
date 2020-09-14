**Kriterier**

- Bara karaktärer från star wars får parkera (swapi.dev)

  - Man får inte cache:a data från APIt utan man måste skicka en förfrågan varje gång det ska kollas
  - Kolla in nuget: RestSharp för att skapa förfrågningar till APIt (Se Stephans projektbeskrivning)
  - Alla förfrågningar ska vara asynchrona

- Appen ska hålla koll på om det är fullt i parkeringen och öppna/stänga därefter

- Det ska finnas frontend, backend och databas och det ska hanteras i olika projekt (men kan ju ligga i samma solution!)

  - Allt ska köras i .Net Core

- Pipelines måste användas

- SKAPA UNIT TESTS!

- Allt som hör till kod och dokumentation ska ligga i GitHub repot

  

- Fokus ska ligga på molntjänster

  - CI

  - CD

  - Deploy

  - Hosting

    - Gör ett val på hur det ska hostas (VM, Container etc.) och motivera varför
    - Allt ska ske i Azure

  - Kostnader

  - Backup

  - Säkerhet

  - Skalbarhet

  - Integrationstester

  - Monitorering

    

- Automatisera set-upen av ditt system

  - Pulumi för IaC

  - Containers

  - Scripts för PowerShell

  - etc.

    

- Ska fortfarande vara enkelt att testa, utveckla och köra lokalt

- Var noga med dokumentation

- Använd markdown

  - Blogg
  - Beskrivningen av vår lösning
    - Planeringsdokument
    - Tankar bakom lösningen
    - Beskrivning av hur lösningen fungerar
    - Källor och källhänvisningar



- En Video ska skapas som del av inlämningen



**TIPS**

- Stäng alltid ned Azure-resurser när de inte används.
- Refaktorera ofta.
- Skriv ned vad vi lär oss och hittar i dokumentationen (både positivt och negativt).
- Var noga med vad som ska ligga i versionskontrollen (https://hackernoon.com/what-should-be-in-version-control-d5f16e9a2bf2)

