namespace Labb_2
{
    public class Rat : Enemy
    {
        private Random random = new Random();

        public Rat(int x, int y)
            : base(
                x,
                y,
                'R',
                "Rat",
                10,
                new Dice(1, 6, 3),
                new Dice(1, 6, 1))
        {
        }

        public override void Update(int playerX, int playerY)
        {
            int direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    Y--;
                    break;

                case 1:
                    Y++;
                    break;

                case 2:
                    X--;
                    break;

                case 3:
                    X++;
                    break;
            }
        }
    }
}