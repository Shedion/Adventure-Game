namespace Adventure_game
{
    class Enemy : Entity
    {
        public Enemy(string name, int health, int attack) : base(name, health, attack)
        {
        }

        public string ArmorValue { get; internal set; }

    }
}
