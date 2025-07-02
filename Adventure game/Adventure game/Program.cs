namespace Adventure_game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Maak een nieuw Player object aan met standaardwaarden
            Player player = new("Default", 100, 25);

            Enemy enemy = null;

            writeThis("Welcome adventurer");
            writeThis("You wake up in a mysterieus fantasy world.");
            writeThis("You see an old puppet in front of you.");
            writeThis("My name is Elder Sack, What is your name, player? ");
            string playerName = Console.ReadLine();

            // Stel de naam van de speler in
            player.SetName(playerName);

            writeThis("Hello " + playerName + "!" + " Welkom to Litlle Big Planet!");
            writeThis("You are the chosen one to save our world from the evil that has taken over our world.");
            writeThis("You are a small puppet, that has to go through various levels and collect diffrent types of collectibles.");
            writeThis("You have to avoid obstacles and enemies to reach the end of the level.");
            writeThis("At the end you have to fight the boss to save all the people of the you village woke up in, Sacktown.");
            writeThis("Good luck on your adventure " + playerName + "!");

            writeThis("Press any key to continue", ConsoleColor.DarkMagenta, true);
            Console.ReadKey();

            bool gameOver = false;
            while (!gameOver)
            {
                if (enemy == null)
                {
                    Random random = new();
                    int enemyType = random.Next(0, 3); // Generate a random number between 0 and 2 (inclusive)

                    switch (enemyType)
                    {
                        case 0:
                            enemy = new Enemy("Goblin", 80, 20);
                            break;
                        case 1:
                            enemy = new TankEnemy("Tank Goblin", 100, 10, 20);
                            writeThis("The " + enemy.Name + " has " + ((TankEnemy)enemy).ArmorValue + " armor value.", ConsoleColor.Red);
                            break;
                        case 2:
                            enemy = new BlitzEnemy("Blitz Goblin", 75, 15);
                            writeThis("The " + enemy.Name + " attacks " + player.Name + " for " + enemy.Attack + " damage!", ConsoleColor.Red);
                            break;
                    }

                    writeThis("A wild " + enemy.Name + " appears!\n", ConsoleColor.Red);
                }

                writeThis("You have " + player.Health + " health and " + player.Attackp + " attack damage.", ConsoleColor.Green);
                writeThis("The " + enemy.Name + " has " + enemy.Health + " health and " + enemy.Attack + " attack damage.\n", ConsoleColor.Red);

                writeThis("What would you like to do? (Attack/Run/Heal):", ConsoleColor.Cyan, true);
                string action = Console.ReadLine()?.ToLower();

                if (action == "attack")
                {
                    Random random = new Random();
                    bool isCriticalHit = random.NextDouble() < player.CriticalRate; // Bepaal of het een critical hit is
                    int playerDamage = player.Attackp; // Gebruik de aanval van de speler direct

                    if (isCriticalHit)
                    {
                        playerDamage = (int)(playerDamage * player.CriticalDamage); // Pas extra schade toe
                        writeThis("Critical hit! You deal massive damage! ");
                    }

                    enemy.TakeDamage(playerDamage);
                    writeThis("You attack the " + enemy.Name + " for " + playerDamage + " damage!", ConsoleColor.Green);

                    if (enemy.Health <= 0)
                    {
                        writeThis("You have defeated the " + enemy.Name + "!\n", ConsoleColor.Green);
                        player.GainExp(100); // Gain experience for defeating the enemy
                        enemy = null; // Enemy is defeated, set to null to spawn a new one
                    }
                }
                else if (action == "run")
                {
                    writeThis("You run into the bushes and lose the " + enemy.Name + "!\n", ConsoleColor.Green);
                    enemy = null; // Enemy is lost, set to null to spawn a new one
                }
                else if (action == "heal")
                {
                    player.Heal(20); // Heal the player by 20 health points
                    writeThis("You heal yourself for 20 health points!", ConsoleColor.Green);
                }
                else
                {
                    writeThis("Invalid action! Please try again.", ConsoleColor.Yellow);
                }

                if (enemy != null)
                {
                    if (enemy is BlitzEnemy blitzEnemy)
                    {
                        blitzEnemy.AttackPlayer(player); // BlitzEnemy kan meerdere keren aanvallen
                    }
                    else
                    {
                        int enemyDamage = enemy.Attack; // Use enemy's attack value directly
                        player.TakeDamage(enemyDamage);
                        writeThis("The " + enemy.Name + " attacks you for " + enemyDamage + " damage!\n", ConsoleColor.Red);
                    }

                    if (player.Health <= 0)
                    {
                        writeThis("You have been defeated by the " + enemy.Name + "!\n", ConsoleColor.Red);
                        gameOver = true;
                    }
                }
            }

            writeThis("Game Over!", ConsoleColor.Magenta, true);

            // Wait for user input before closing
            writeThis("Press any key to exit...", ConsoleColor.White, true);
            Console.ReadKey();

            void writeThis(string text, ConsoleColor kleur = ConsoleColor.Blue, bool useWriteLine = false)
            {
                Console.ForegroundColor = kleur;

                if (useWriteLine)
                {
                    Console.WriteLine(text);
                }
                else
                {
                    foreach (char c in text)
                    {
                        Console.Write(c);
                        Thread.Sleep(0);
                    }
                    Console.WriteLine();
                }

                Console.ResetColor();
            }
        }
    }
}

