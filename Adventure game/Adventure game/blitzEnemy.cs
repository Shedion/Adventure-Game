using System.Xml.Linq;

namespace Adventure_game
{
    class BlitzEnemy : Enemy
    {
        private double attackChance;
        private const double chanceDecay = 0.1; // Hoeveel de kans afneemt na elke aanval

        public BlitzEnemy(string name, int health, int attack)
            : base(name, health, attack)
        {
            attackChance = 0.8; // Begin met een hoge kans
        }

        public virtual void AttackPlayer(Player player)
        {
            Random random = new();
            do
            {
                player.TakeDamage(Attack);
                Console.WriteLine($"{Name} attacks {player.Name} for {Attack} damage!");

                attackChance -= chanceDecay; // Verlaag de kans
            } while (random.NextDouble() < attackChance);

            attackChance = Math.Max(0, attackChance); // Zorg dat de kans niet negatief wordt
        }
    }
}
