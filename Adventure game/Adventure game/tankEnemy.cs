namespace Adventure_game
{
    class TankEnemy : Enemy
    {
        public new int ArmorValue { get; private set; }

        public TankEnemy(string name, int health, int attack, int armorValue)
            : base(name, health, attack)
        {
            ArmorValue = armorValue;
        }

        public  new void TakeDamage(int damage)
        {
            int reducedDamage = Math.Max(damage - ArmorValue, 0); 
            base.TakeDamage(reducedDamage);
            if (Health <= 50)
            {
                Console.WriteLine($"{Name} took {reducedDamage} damage after armor reduction. Remaining health: {Health}");
            }

        }
    }
}
