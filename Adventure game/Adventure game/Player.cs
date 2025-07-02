namespace Adventure_game
{
    class Player : Entity
    {
        public int MaxHealth { get; private set; }
        public int Attackp { get; private set; } // Attack for player
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public int ExpThreshold { get; private set; }
        public double CriticalRate { get; private set; }
        public double CriticalDamage { get; private set; } // Extra schade bij een critical hit (bijv. 1.5x)

        public Player(string name, int health, int attack) : base(name, health, attack)
        {
            MaxHealth = health;
            Attackp = attack;
            Level = 1;
            Exp = 0;
            ExpThreshold = 100; // Set the initial experience threshold for leveling up
            CriticalRate = 0.7; // 30% kans op een critical hit
            CriticalDamage = 1.5; // 50% extra schade bij een critical
        }

        public void Heal(int amount)
        {
            SetHealth(Health + amount);
            if (Health > MaxHealth)
            {
                SetHealth(MaxHealth);
            }
        }
        public void GainExp(int amount)
        {
            Exp += amount;
            Console.WriteLine($"You gained {amount} experience points!");

            while (Exp >= ExpThreshold)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
                while (Exp >= ExpThreshold)
            {
                Exp -= ExpThreshold;
                Level++;
                MaxHealth += 10;
                ExpThreshold += 50;
                Attackp += 5;

                Console.WriteLine($"Congratulations! You leveled up to level {Level}!");
                Console.WriteLine($"Your max health is now {MaxHealth} and your attack is now {Attackp}!");

                SetHealth(MaxHealth); // Restore health to max after leveling up
            }
        }
    }
}
