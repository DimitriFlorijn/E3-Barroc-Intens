# Code Conventions

Dit document beschrijft de code conventions die moeten worden gevolgd om de leesbaarheid, onderhoudbaarheid en consistentie van de codebase te waarborgen.

## Inhoudsopgave
1. [Naming Conventions](#naming-conventions)
2. [Indentatie](#indentatie)
3. [Wit Ruimte's](#witte-ruimte)
4. [Commentaar](#commentaar)
5. [Functies](#functies)
6. [Fout Preventie](#Fout-Preventie)
7. [Bestandsnamen en Mappenstructuur](#bestandsnamen-en-mappenstructuur)
   -[Mappen](#mappen)
   -[Bestanden](#bestanden)

---

## Naming Conventions
- **Variabelen en functies**: Gebruik `UperCamelCase` voor variabelen en functies.

## Wit Ruimte's
- niet al te veel witruimtes > hou het beperkt tot max 1 regel ertussen

## Indentatie
- **indentatie**: parent child relation 

## Commentaar
- **comments**: gebruik bij wat complexere dingen en bijv niet bij het standart crud reeks.

## Functies
- een Db link dat er met een functie om in te kunnen loggen en van hun afdeling hun projecten kunnen doen en dat het intern gecomuniceerd word

## Fout Preventie
- voor fouten eerst kijken en weeten wat er fout is en dan noog niet git pushen zoadat er geen foute kode guplublished woordt en dat er geen gitconflicten er komen

## Bestandsnamen en Mappenstructuur
- De structuur en naamconventies zijn vastgesteld in de alpha-versie van het project.
- Hieronder vind je een uitleg over de structuur.

### Mappen
- Mappen zijn verdeeld in drie categorieën:
  1. Eerste rangs
  2. Tweede rangs
  3. Derde rangs

#### Eerste Rangs
- Mapnamen zijn in het Engels en beginnen met een hoofdletter.
- Voorbeelden van eerste rangs mappen:
  1. Finance
  2. Sales
  3. Maintenance

- Deze mappen worden genoemd naar de afdelingsnamen van Barroc Intens. Namen van eerste rangs mappen kunnen daarvan niet afwijken. Voorbeelden van incorrecte namen:
  1. finance (begint niet met een hoofdletter)
  2. Verkoop (is geen afdelingsnaam binnen Barroc Intens)
  3. Onderhoud (is in het Nederlands, niet in het Engels)

- In de eerste rangs map bevinden **alleen** mappen van de tweede rang en **niks** anders. 

#### Tweede Rangs
- Voor tweede rangs mappen gelden grotendeels dezelfde conventies als bij de eerste rangs, met twee afwijkingen:
  1. Namen zijn gebaseerd op beroep in plaats van afdeling.
  2. Andere bestanden mogen daar ook in staan. **Let op**: Dit geldt alleen voor bestanden die bij dat beroep horen. Bestanden die niet bij dat beroep horen, mogen daar niet in worden opgeslagen. Bestanden die bij het beroep "planner" horen, mogen bijvoorbeeld niet worden opgeslagen in de map voor het beroep "inkoper".

- Mappen die in een tweede rangs map zitten, worden derde rangs mappen genoemd. Derde rangs mappen zijn *optioneel*, maar het gebruik ervan wordt aangeraden voor een nettere mappenstructuur. In een derde rangs map vind je bestanden die een aparte locatie hebben omdat ze een functionaliteit van het hoofdbestand ondersteunen. Een voorbeeld: de inkoper ziet op het dashboard in de tweede rangs map van inkoop dat van bepaalde producten de voorraad bijna op is. De inkoper kan dan op een product klikken en wordt geleid naar de inkooppagina die in een derde rang map zit om daar de aankoop van het product te voltooien.

### bestanden
