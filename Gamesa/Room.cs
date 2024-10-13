namespace Gamesa;

public class Room
{
    public string Description { get; set; }
    public Enemy Enemy { get; private set; }

    public Room(string description, bool hasChest, bool hasBoss)
    {
        Description = description;
        Enemy = GenerateEnemy();
    }
    
    private Enemy GenerateEnemy()
    {
        Random rnd = new Random();
        int randomEnemy = rnd.Next(0, 3); 

        switch (randomEnemy)
        {
            case 0: return Enemy.Factory.CreateOger();
            case 1: return Enemy.Factory.CreateGoblin();
            default: return null; 
        }
    }

    public void Explore()
    {
        Console.WriteLine("omg to je truhla \n 1.otevrit 2.nebudu to riskovat");
        int chest = Convert.ToInt32(Console.ReadLine());
        switch (chest)
        {
           
        }

    }

    public void StartBattle(Player player, Enemy enemy)
    {
        while (player.IsLiving && enemy.IsLiving)
        {
            Console.WriteLine(Description);
            Console.WriteLine("1.fight  2.odejit");
            int battle = Convert.ToInt32(Console.ReadLine());
            switch (battle)
            {
                case 1:
                    while (player.IsLiving && enemy.IsLiving)
                    {
                        player.Attack(enemy);
                        enemy.Attack(player);
                    }
                    break;
                
                /*case 2:
                    Console.WriteLine("1.Heal potions  2.Strength potions");
                    int potionChoose = Convert.ToInt32(Console.ReadLine());
                    switch (potionChoose)
                    {
                        case 1:
                            Console.WriteLine("1.small  2.medium  3.large");
                            int healPotions = Convert.ToInt32(Console.ReadLine());
                            switch (healPotions)
                            {
                                case 1:
                                    player.Heal(Player.EHealPotions.naplast);
                                    Console.WriteLine("plus 7 hp bro");
                                    break;
                                case 2:
                                    player.Heal(Player.EHealPotions.bandaz);
                                    Console.WriteLine("plus 10 hp bro");
                                    break;
                                case 3:
                                    player.Heal(Player.EHealPotions.medkit);
                                    Console.WriteLine("plus 15 hp bro");
                                    break;
                            }
                            break;
                        case 2: Console.WriteLine("1.small  2.medium  3.large");
                            int strengthPotions = Convert.ToInt32(Console.ReadLine());
                            switch (strengthPotions)
                            {
                                case 1:
                                    player.IncreaseDamage(Player.EStrengthPotions.small);
                                    Console.WriteLine("plus 1 dmg bro");
                                    break;
                                case 2:
                                    player.IncreaseDamage(Player.EStrengthPotions.medium);
                                    Console.WriteLine("plus 3 dmg bro");
                                    break;
                                case 3:
                                    player.IncreaseDamage(Player.EStrengthPotions.large);
                                    Console.WriteLine("plus 5 dmg bro");
                                    break;
                            }
                            break;
                    }
                    break;*/
            }

            if (enemy.Hp <= 0)
            {
                Console.Write("vyhravas");
            }
            else if (player.Hp <= 0)
            {
                Console.Write($"{enemy.Name} te zmlatil");
            }
            
        }
        Console.ReadLine();
    }
}