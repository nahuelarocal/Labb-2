namespace Labb_2
{
    public abstract class Enemy : LevelElement
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }

        public Dice AttackDice { get; protected set; }
        public Dice DefenceDice { get; protected set; }

        public Enemy(
            int x,
            int y,
            char symbol,
            string name,
            int hp,
            Dice attackDice,
            Dice defenceDice)
            : base(x, y, symbol)
        {
            Name = name;
            HP = hp;
            AttackDice = attackDice;
            DefenceDice = defenceDice;
        }

        public bool IsAlive()
        {
            return HP > 0;
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;

            if (HP < 0)
            {
                HP = 0;
            }
        }

        public int Attack()
        {
            return AttackDice.Throw();
        }

        public int Defend()
        {
            return DefenceDice.Throw();
        }

        public abstract void Update(int playerX, int playerY);
    }
}