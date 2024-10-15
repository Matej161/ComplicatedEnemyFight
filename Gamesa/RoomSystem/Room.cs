namespace Gamesa;

public class Room
{
    public string Description { get; set; }
    public Enemy Enemy { get; private set; }

    public bool HasChest;
    public bool HasBoss;
    public bool EnemyCleared { get; private set; }
    public bool ChestCleared { get; private set; }

    public Room(string description, bool hasChest, bool hasBoss)
    {
        Description = description;
        Enemy = GenerateEnemy();
        HasChest = hasChest;
        HasBoss = hasBoss;
        EnemyCleared = false;
        ChestCleared = false;
    }

    private Enemy GenerateEnemy()
    {
        Random rnd = new Random();
        int randomEnemy = rnd.Next(0, 7);

        switch (randomEnemy)
        {
            case 0: return Enemy.Factory.CreateOger();
            case 1: return Enemy.Factory.CreateGoblin();
            case 2: return Enemy.Factory.CreateSkeleton();
            case 3: return Enemy.Factory.CreateSpider();
            case 4: return Enemy.Factory.CreateZombie();
            case 5: return Enemy.Factory.CreateUrban();
            case 6: return Enemy.Factory.CreateBohata();
        }

        return null;
    }

    public void Yapping()
    {
        if (Enemy != null && !Enemy.IsDefeated)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"V místnosti se nachází {Enemy.Name}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("V místnosti není žádný nepřítel.");
        }

        if (HasChest)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("V místnosti je truhla.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Truhla byla vyloupena");
        }
    }

    public bool Explore(Player player)
    {
        if (EnemyCleared && ChestCleared)
        {
            Console.WriteLine("Tato místnost byla již vyčištěna. Není tu žádný nepřítel a žádná truhla.");
            return false; 
        }
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"1.Attack {Enemy.Name} 2.Otevřít bednu 3.Zobrazit inventář 4.Vyhealovat se 5.Zobrazit stats 6.Odejít");
        int playerAction = Convert.ToInt32(Console.ReadLine());
        switch (playerAction)
        {
            case 1:
                if (!Enemy.IsDefeated && !EnemyCleared)
                {
                    StartBattle(player, Enemy);
                    if (Enemy.IsDefeated)
                    {
                        EnemyCleared = true;
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Už je mrtvý");
                    Explore(player);
                    Console.Clear();
                }
                break;
            
            case 2:
                if (HasChest && !ChestCleared)
                {
                    Random rnd = new Random();
                    Player.EHealPotions potion = (Player.EHealPotions)rnd.Next(0, 3);
                    player.PlayerInventory.AddPotion(potion);
                    HasChest = false;
                    ChestCleared = true;
                }
                else
                {
                    Console.WriteLine("je prázdná");
                }
                Explore(player);
                break;
            
            case 3:
                player.PlayerInventory.ShowPotions();
                Explore(player);
                break;
            case 4:
                player.PlayerInventory.UsePotion(player);
                Explore(player);
                break;
            
            case 5:
                player.ShowStats(player);
                Explore(player);
                break;
            
            case 6:
                Console.Clear();
                return true;
        }

        return false;
    }

    public void StartBattle(Player player, Enemy enemy)
    {
        while (player.IsLiving && enemy.IsLiving)
        {
            player.Attack(enemy);

            if (!enemy.IsLiving)
            {
                Enemy.IsDefeated = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{enemy.Name} byl poražen");
                break;
            }

            if (enemy.Name == "Boss")
            {
                enemy.Attack(player);
            }
            
            enemy.Attack(player);

            if (!player.IsLiving)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Smrt pro tebe.");
                break;
            }
        }

        if (!enemy.IsLiving)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vyhrál jsi souboj!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Chceš vzít {enemy.DroppedWeapon.Name} z bluda? 1.ano 2.ne");
            int takeWeapon = Convert.ToInt32(Console.ReadLine());

            if (takeWeapon == 1) player.EquipWeapon(enemy.DroppedWeapon);
            Explore(player);
        }
        else if (!player.IsLiving)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("**********" + "\n" + " GAME OVER " + "\n" + "**********" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Vypni kliknutim libovolného tlačítka...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}