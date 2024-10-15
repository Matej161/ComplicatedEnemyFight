namespace Gamesa;

public class Room
{
    public string Description { get; set; }
    public Enemy Enemy { get; private set; }

    public bool HasChest;
    public bool HasBoss;

    public Room(string description, bool hasChest, bool hasBoss)
    {
        Description = description;
        Enemy = GenerateEnemy();
        HasChest = hasChest;
        HasBoss = hasBoss;
    }

    private Enemy GenerateEnemy()
    {
        Random rnd = new Random();
        int randomEnemy = rnd.Next(0, 2);

        switch (randomEnemy)
        {
            case 0: return Enemy.Factory.CreateOger();
            case 1: return Enemy.Factory.CreateGoblin();
        }

        return null;
    }

    public void Yapping()
    {
        if (Enemy != null && !Enemy.IsDefeated)
        {
            Console.WriteLine($"V místnosti je nepřítel: {Enemy.Name}");
        }
        else
        {
            Console.WriteLine("V místnosti není žádný nepřítel.");
        }

        if (HasChest)
        {
            Console.WriteLine("V místnosti je truhla.");
        }
        else
        {
            Console.WriteLine("Truhla byla vyloupena");
        }
    }

    public void Explore(Player player)
    {
        Console.WriteLine($"1.attack {Enemy.Name}  2.open truhla 3.see inventory 4.popnout potion  5.leave");
        int playerAction = Convert.ToInt32(Console.ReadLine());
        switch (playerAction)
        {
            case 1:
                if (!Enemy.IsDefeated)
                {
                    StartBattle(player, Enemy);
                }
                break;
            
            case 2:
                if (HasChest)
                {
                    Random rnd = new Random();
                    Player.EHealPotions potion = (Player.EHealPotions)rnd.Next(0, 3);
                    player.PlayerInventory.AddPotion(potion);
                    HasChest = false;
                }
                else
                {
                    Console.WriteLine("uz je prazdna");
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
                
                break;
        }

        Console.ReadLine();
    }

    public void StartBattle(Player player, Enemy enemy)
    {
        while (player.IsLiving && enemy.IsLiving)
        {
            player.Attack(enemy);

            if (!enemy.IsLiving)
            {
                Enemy.IsDefeated = true;
                Console.WriteLine($"{enemy.Name} byl porazen");
                
                break;
            }

            enemy.Attack(player);

            if (!player.IsLiving)
            {
                Console.WriteLine("umrel si gg");
                break;
            }
        }

        if (!enemy.IsLiving)
        {
            Console.WriteLine("Vyhrál jsi souboj!");
            Console.WriteLine("Chceš vzít zbraň z bluda? (1 = ano, 2 = ne)");
            int takeWeapon = Convert.ToInt32(Console.ReadLine());

            if (takeWeapon == 1)
            {
                player.EquipWeapon(enemy.DroppedWeapon);
            }
            Explore(player);
        }
        else if (!player.IsLiving)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("**********" + "\n" + " GAME OVER " + "\n" + "**********" + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}