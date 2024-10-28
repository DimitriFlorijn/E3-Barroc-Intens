# E3-Barroc-Intens
## Acties voordat je met het project gaat starten
### Fetchen
- het project fetchen volgens de nieuwe updates van het bestand die op het moment beschikbaar zijn.
- Als je Github Desktop gebruikt kan je het via Github Desktop doen, om daar naar een repo te zoeken of via de Github Browser en dan Github deskTop te laten opstarten. Zorg dat je wel een map hebt waar die het kan opslaan Github Desktop.
### project opstarten in Visual Studio
- Je moet het project openen in Visual Studio. Daarvoor ga je naar de map E3_Barroc_Intens en dan dubbel klik je op het bestand E3_Barroc_Intens.sln. Dan opent Visual Studio het bestand en kan je naar de volgende stap.
### Nuget Packages Managen
- Als Visual Studio is geopent, klik je met je rechter muis knop op de naam E3_Barroc_Intens, onder de naam Solution 'E3_Barroc_Intens'. Doe dat tot je een lijst met keuzes ziet verschijnen. 
- Dan als je dat hebt gedaan opent een keuze lijst en daar klik je op Manage Nuget Packages. Als je daar klikt opent een scherm waar je de Nuget Packages kan zoeken, instaleeren en updaten.
- Kijk bij de installeren scherm van de Nuget Packages of je Nuget packages kan importeren, anders moet je de volgende Nuget Pckages zoeken en installeren. controleer ook of je alle Nuget Packages hebt als er Nuget Packages in de installeren scherm staat.
#### Vereiste Nuget Packages
1. Pomelo.EntityFrameworkCore.MySql (versie 8.0.2)
2. System.Text.Json (versie 8.0.5)
3. System.Configuration.ConfigurationManager (versie 8.0.1)
- Dat zijn de Nuget Packages die je nodig hebt om het project te kunnen laten werken. EfCore wordt genomen door de Package bij nummer 1.
- Als je alle Nuget Packages hebt kan je het schrem voor de Nuget Packages sluiten.
### App.config
- Nu heb je de Nuget Packages goed ingesteld en nu is het tijd om een bestand te hernoemen.
- Open de folder Data door op het driehoekje naast de folder icoon en dubbel klik op het bestand App.config.example.
- zoek naar de locatie waar je jouw database gegevens invult. Daar zie je dat er al een aantal gegevens zijn ingevult, namelijk server en poort. vul zelf de user, password (wachtwoord van de gebruiker) en een database naam in.
- sla het bestand op met ctl + s en dan klik je rechts in de solution explorer op de bestandsnaam App.config.example met jouw rechter muis knop. Dan opent weer een lijst met keuzes. Klik daar op rename en hernoem het bestand van App.config.example naar App.config.
### Project starten
- als je de stappen hierboven hebt gevolgd zou alles nu moeten werken. Klik boven in de sneltoetsbar op de tekst E3_Barroc_Intens (Package). Als je daar op klikt wordt het project gebouwt op jouw laptop. **Let op**: Zorg wel dat de database aanstaat, zo niet zorg dat die eerst aanstaat, voordat je het project laat gaat starten. Als je dat niet doet dan krijg je een foutmelding, omdat die dan niet kan verbinden met de database.
# WireFrame > https://miro.com/welcomeonboard/NWtvZ0VPZ2VWQTRWbkhtODF1dXlSUWJvNzZmdkVzUmZYb2hkZDZCTmNmakh0RGVPSm0zMG83bUhodmFVN051N3wzNDU4NzY0NTMzNTE1ODIzNzU2fDI=?share_link_id=719094101564
