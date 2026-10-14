namespace Labb_2
{
    public class Player : LevelElement
    {
        public int HP { get; private set; }

        public Dice AttackDice { get; private set; }
        public Dice DefenceDice { get; private set; }

        public Player(int x, int y)
            : base(x, y, '@')
        {
            HP = 100;

            AttackDice = new Dice(2, 6, 2);
            DefenceDice = new Dice(2, 6, 0);
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public int Attack()
        {
            return AttackDice.Throw();
        }

        public int Defend()
        {
            return DefenceDice.Throw();
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;

            if (HP < 0)
            {
                HP = 0;
            }
        }

        public bool IsAlive()
        {
            return HP > 0;
        }
    }
}
