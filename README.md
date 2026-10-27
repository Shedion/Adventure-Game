# Adventure Game

Een turn-based RPG in de console, gemaakt in C#. Je wordt wakker in een fantasiewereld en vecht tegen golven goblins om het dorp Sacktown te redden. Versla vijanden, verdien ervaring en word steeds sterker, tot je zelf verslagen wordt.

Gemaakt tijdens de opleiding Software Developer (mbo 4) aan het Deltion College, om te oefenen met objectgeoriënteerd programmeren in C#.

## Hoe je speelt

Je kiest eerst een naam voor je personage. Daarna verschijnt er telkens een willekeurige vijand en kies je elke beurt wat je doet:

| Actie | Wat er gebeurt |
|---|---|
| `attack` | Je valt aan, met een kans op een **critical hit** die 1,5× schade doet |
| `heal` | Je herstelt 20 health (nooit meer dan je maximum) |
| `run` | Je vlucht en er verschijnt een nieuwe vijand |

Na jouw beurt slaat de vijand terug. Het spel gaat door tot je health op 0 staat.

## Vijanden

| Vijand | Health | Aanval | Speciaal |
|---|---|---|---|
| Goblin | 80 | 20 | Gewone vijand |
| Tank Goblin | 100 | 10 | Heeft **armor** die inkomende schade verlaagt |
| Blitz Goblin | 75 | 15 | Kan **meerdere keren per beurt** aanvallen; de kans daarop wordt na elke aanval kleiner |

## Levelsysteem

- Elke verslagen vijand levert 100 XP op
- Bij een level-up krijg je +10 max health en +5 aanval, en word je volledig geheeld
- Voor elk volgend level heb je 50 XP meer nodig

## Opbouw van de code

Het project draait om **overerving**: alle personages delen een basisklasse.

```
Entity              ← naam, health, aanval, schade ontvangen
├── Player          ← levels, XP, critical hits, healen
└── Enemy
    ├── TankEnemy   ← verlaagt schade met armor
    └── BlitzEnemy  ← meerdere aanvallen per beurt
```

| Bestand | Inhoud |
|---|---|
| `Program.cs` | De game-loop: vijanden laten verschijnen, invoer van de speler verwerken, gekleurde tekst tonen |
| `Entity.cs` | Basisklasse voor alle personages |
| `Player.cs` | De speler, met het levelsysteem en critical hits |
| `Enemy.cs`, `tankEnemy.cs`, `blitzEnemy.cs` | De verschillende soorten vijanden |

## Gebruikte technieken

- C# / .NET 9 (console-applicatie)
- Objectgeoriënteerd programmeren: klassen, overerving, properties
- Visual Studio

## Zelf spelen

Je hebt de [.NET 9 SDK](https://dotnet.microsoft.com/download) nodig.

```bash
git clone https://github.com/Shedion/Adventure-Game.git
cd "Adventure-Game/Adventure game"
dotnet run
```

Of open het project in Visual Studio en druk op **Start**.
