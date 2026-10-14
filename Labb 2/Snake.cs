namespace Labb_2
{
    public class Snake : Enemy
    {
        public Snake(int x, int y)
            : base(
                x,
                y,
                'S',
                "Snake",
                25,
                new Dice(3, 4, 2),
                new Dice(1, 8, 5))
        {
        }

        public override void Update(int playerX, int playerY)
        {
            int distanceX = Math.Abs(playerX - X);
            int distanceY = Math.Abs(playerY - Y);

            int distance = distanceX + distanceY;

            if (distance <= 2)
            {
                if (playerX > X)
                {
                    X++;
                }
                else if (playerX < X)
                {
                    X--;
                }
                else if (playerY > Y)
                {
                    Y++;
                }
                else if (playerY < Y)
                {
                    Y--;
                }
            }
        }
    }
}