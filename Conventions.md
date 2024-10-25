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
- volgens de structuur die in de alpha versie is vastgesteld.
- Hieronder vind je een uitleg over de structuur

### mappen
- Mappen zijn verdeelt in drie categrorieen.
  1. Eerste rangs
  2. Tweede rangs
  3. Derde rangs
 
#### eerste rangs
- mapnamen zijn in het engels en beginnen met een hoofdletter zoals hieronder beschreven.
- 1. Finance
- 2. Sales
- 3. Maintanance.
- Dat soort mappen heten in het project de eerste rang map. Die worden beschreven volgens de afdelingsnaam van Barroc Intens. Namen van eerste rangs mappen kunnen daarvan niet afwijken. Hoe de mappen van de eerste rang niet hun naam hebben beschreven vindt je voorbeelden hieronder.
- 1. finance (begingt niet met een hoofdletter).
- 2. Verkoop (is geen afdelingsnaam binnen Barroc Intens).
- 3. Onderhoud (is in het nederlands. niet in het engels).
- In de eerste rangs map bevinden **alleen** mappen van de tweede rang en **niks** anders. Voor tweede rangs mappen geldt in groote lijnen dezelfde conventies als bij de eerste rangs mappen. Voor de tweede rangs mappen zijn er maar 2 afwijkingen van de eerste rangs mappen conventie. De afwijkingen vind je hieronder.
- 1. namen zijn niet op afdeling, maar op beroep.
- 2. andere bestanden mogen er ook daar in. **Let op**: dit geld alleen voor de bestanden die bij dat beroep horen. Bestanden die niet bij dat beroep horen mogen daar ook niet in worden opgeslagen. Bestanden die bij het beroep planner horen, mogen niet worden opgeslagen bij de map bij het beroep inkoper.
- Mappen die in een tweede rangs map zitten worden derde rangs map genoemt. De derde rangs map is *optioneel*, maar wordt wel aangeraden om te gebruiken voor de netheid van de mappenstructuur. In een derde rangs map vind je bestanden die een apparte locatie hebben, omdat ze een functionaliteit van het hoofdbestand ondersteunen. Een voorbeeld is het inkopen van producten. De inkoper ziet bv. op het dashboard in de tweede rangs map van inkoop dat van bepaalde producten de voorraad bijna op is. De inkoper kan dan op een product klikken en wordt geleid naar de inkooppagina die in een derde rang map zit om daar de aankoop van het product te voltooien.

### bestanden
