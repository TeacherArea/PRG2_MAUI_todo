# MAUI TODO App

## Beskrivning
Det här projektet är en TODO-app utvecklad med MAUI (Multi-platform App UI), som syftar till att demonstrera grundläggande MAUI-funktioner samt objektorienterad programmering i C#. Appen låter användare skapa, hantera, och även spara sina att-göra-listor i JSON-format. Projektet är av pedagoiskt art där nivån bedöms vara *Programmering 1* för gymnasiet. I en av brancherna finns en enkel julvariant.

## Funktioner
- Skapar nya TODO-uppgifter
- Visa en lista av uppgifter
- Markera uppgifter som avklarade
- Radera uppgifter
- Spara uppgifter i en JSON-fil
- Läsa uppgifter från en JSON-fil

## Tekniker
- MAUI: För att skapa en multi-plattform app
- C#: Programmeringsspråk
- .NET 9 eller senare: Backend-ramverk
- System.Text.Json: För att hantera JSON-filer

## Hur man kör projektet
- Klona repo till din dator och öppna i din IDE (t.ex. Visual Studio).
- Bygg och kör projektet.
- Använd appen genom att lägga till/uppdatera/ta bort TODO-uppgifter.

## Projektstruktur
- TodoItem.cs: Definierar en TODO-uppgift.
- TodoManager.cs: Hanterar en lista av TodoItem.
- TodoFileManager.cs: Hanterar sparning och läsning av TODO-listor till/från en JSON-fil.
- Grundläggande OOP-struktur

## Bidrag
Om du vill bidra till projektet, vänligen följ dessa steg:

1. Forka projektet.
2. Skapa en ny gren (git checkout -b feature/AmazingFeature).
3. Gör dina ändringar, commita (git commit -m 'Add some AmazingFeature') och pusha (git push origin feature/AmazingFeature).
4. Öppna en Pull Request.
