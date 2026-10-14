namespace Labb_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            LevelData level = new LevelData();
            level.Load("level1.txt");

            Player player = new Player(2, 2);

            bool gameRunning = true;

            while (gameRunning && player.IsAlive())
            {
                Console.Clear();

                DrawLevel(level, player);

                Console.SetCursorPosition(0, 20);
                Console.WriteLine("HP: " + player.HP);
                Console.WriteLine("WASD = move | Q = quit");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                {
                    gameRunning = false;
                    break;
                }

                int newX = player.X;
                int newY = player.Y;

                if (key.Key == ConsoleKey.W)
                {
                    newY--;
                }
                else if (key.Key == ConsoleKey.S)
                {
                    newY++;
                }
                else if (key.Key == ConsoleKey.A)
                {
                    newX--;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    newX++;
                }
                else
                {
                    continue;
                }

                LevelElement element =
                    level.GetElementAt(newX, newY);

                if (element is Wall)
                {
                    continue;
                }

                if (element is Enemy enemy)
                {
                    Fight fight = new Fight(player, enemy);
                    fight.Start();

                    if (!enemy.IsAlive())
                    {
                        level.Elements.Remove(enemy);
                    }

                    if (!player.IsAlive())
                    {
                        break;
                    }
                }
                else
                {
                    player.Move(
                        newX - player.X,
                        newY - player.Y
                    );
                }

                foreach (LevelElement levelElement in level.Elements)
                {
                    if (levelElement is Enemy currentEnemy)
                    {
                        int oldX = currentEnemy.X;
                        int oldY = currentEnemy.Y;

                        currentEnemy.Update(player.X, player.Y);

                        bool blocked = false;

                        foreach (LevelElement other in level.Elements)
                        {
                            if (other == currentEnemy)
                            {
                                continue;
                            }

                            if (other.X == currentEnemy.X &&
                                other.Y == currentEnemy.Y)
                            {
                                blocked = true;
                                break;
                            }
                        }

                        if (blocked ||
                            (currentEnemy.X == player.X &&
                             currentEnemy.Y == player.Y))
                        {
                            currentEnemy.X = oldX;
                            currentEnemy.Y = oldY;
                        }
                    }
                }
            }

            Console.Clear();

            if (player.IsAlive())
            {
                Console.WriteLine("Spelet avslutades.");
            }
            else
            {
                Console.WriteLine("Du dog!");
            }

            Console.ReadKey(true);
        }

        static void DrawLevel(LevelData level, Player player)
        {
            foreach (LevelElement element in level.Elements)
            {
                double distance = Math.Sqrt(
                    Math.Pow(element.X - player.X, 2) +
                    Math.Pow(element.Y - player.Y, 2)
                );

                if (distance <= 5)
                {
                    element.Draw();
                }
            }

            player.Draw();
        }
    }
}
