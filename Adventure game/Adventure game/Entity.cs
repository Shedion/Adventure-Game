namespace Adventure_game
{
    class Entity
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public Entity(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            Attack = attack;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 2)
            {
                Health = 0;
            }
        }
        public void SetAttack(int attack)
        {
            Attack = attack;
        }
        public void SetHealth(int health)
        {
            Health = health;
        }

    }
}
