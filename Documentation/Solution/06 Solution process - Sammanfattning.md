# 06 Solution process - Sammanfattning

Sammanfattningsvis gick projektet bra. Vissa perioder gick det långsammare än andra; antingen på grund av visst teknikstrul, eller att vi var tvungna att vänta på att vissa issues/moment var tvungna att bli klara innan vi kunde dela upp oss mer. Ett exempel är att databasen var tvungen att skapas och komma upp i Azure i ett tidigt skede innan vi kunde påbörja något annat moment. 

Fokus var främst på vårt API i början, medan vi bestämde oss för vilken frontendlösning som passade bäst för oss. Efter mycket research och testning i sidoprojekt kom vi fram till att vi skulle använda oss av enkel statisk HTML, utan något frontendramverk såsom MVC eller Razorpages. Dels eftersom Razorpages och MVC innefattar en viss inlärningskurva som vi kände att vi inte hade tid med.  Samt resultatet av tidigare testning, som visade på att det går att skapa image-filer av en html-mapp samt lägga upp det i en WebService/Application på Azure och få det att fungera utan problem.

Azure Devops var ett posivit moment, om än lite ovant och svårt i början att sätta sig in i. På en basic-nivå går det väldigt lätt att bygga olika pipelines (bygg och release) och få upp våra builds i Azure. Däremot går det att bygga de olika pipelinesen väldigt avancerat vilket kräver tid för att få erfarenhet i. Antingen steg för steg via Classic Editor, eller via kod inuti .yml-filen samt möjlighet att välja in olika "kodblock" i .yml-filen. Flexibiliteten om hur vi vill bygga dem gör att alla kan hitta sitt sätt, och så klart hur organisationen som man arbetar inom som helhet vill deploya sina projekt.

Azure CLI var ett smidigt komplement om man ej använder sig av Azure Devops, utan direkt vill publicera i Azure Portal. Eller så går det även att implementera CLI in i Azure Devops pipelines via .yml filen.

Azure Portal är portalen där du kan skräddarsy din IT-lösining vare sig det gäller lagring och bevakning eller publik/privat åtkomst till dina IT-tjänster och databaser. Tack vare enkelheten att koppla ihop olika resurser med en Resourcegroup, går det att mixa och matcha hur man vill. Beroende på vilken standard du önskar på dina tjänster tillkommer kostnader. Kostnader som lätt kan springa iväg på grund av alla konfigurationsmöjligheter som finns. Dock finns det gott om val att välja billigare alternativ om organisationen eller tjänsten inte kräver det. Det går även att vid behov att skala upp/ner många av tjänsterna genom att bland annat gå upp ett eller flera steg i kostnadstrappan, för att sedan gå tillbaka ner då behovet lagt sig.

Vill du skapa en riktigt robust IT-lösning för din organisation och dina tjänster så kommer det att kosta. Därför är det väldigt viktigt att räkna på samtliga kostnader. Azure kalkylatorn visar inte alltid alla kostnader och val som går att göra, utan du måste ibland prova att klicka på och skapa tjänsten för att kunna gräva djupare i olika konfigurationsval såväl som kostnader.



