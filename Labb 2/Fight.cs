namespace Labb_2
{
    public class Fight
    {
        private Player player;
        private Enemy enemy;

        public Fight(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
        }

        public void Start()
        {
            while (player.IsAlive() && enemy.IsAlive())
            {
                PlayerTurn();

                if (!enemy.IsAlive())
                {
                    Console.Clear();
                    Console.WriteLine(enemy.Name + " dog!");
                    Thread.Sleep(1000);
                    break;
                }

                EnemyTurn();

                if (!player.IsAlive())
                {
                    Console.Clear();
                    Console.WriteLine("Du dog!");
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        private void PlayerTurn()
        {
            Console.Clear();

            Console.WriteLine("=== FIGHT ===");
            Console.WriteLine();
            Console.WriteLine("Du: " + player.HP + " HP");
            Console.WriteLine(enemy.Name + ": " + enemy.HP + " HP");
            Console.WriteLine();
            Console.WriteLine("Din tur!");
            Console.WriteLine("Tryck ENTER för att attackera.");

            Console.ReadKey(true);

            int attack = player.Attack();
            int defence = enemy.Defend();

            int damage = attack - defence;

            if (damage < 0)
            {
                damage = 0;
            }

            enemy.TakeDamage(damage);

            Console.Clear();

            Console.WriteLine("Du attackerade " + enemy.Name +
                              " och gjorde " + damage + " skada.");

            Console.WriteLine();
            Console.WriteLine(enemy.Name +
                              " har " + enemy.HP + " HP kvar.");

            Thread.Sleep(1000);
        }

        private void EnemyTurn()
        {
            Console.Clear();

            Console.WriteLine("=== FIGHT ===");
            Console.WriteLine();
            Console.WriteLine(enemy.Name + "'s tur...");

            Thread.Sleep(700);

            int attack = enemy.Attack();
            int defence = player.Defend();

            int damage = attack - defence;

            if (damage < 0)
            {
                damage = 0;
            }

            player.TakeDamage(damage);

            Console.Clear();

            Console.WriteLine(enemy.Name +
                              " attackerade dig och gjorde " +
                              damage + " skada.");

            Console.WriteLine();
            Console.WriteLine("Du har " +
                              player.HP + " HP kvar.");

            Thread.Sleep(1000);
        }
    }
}