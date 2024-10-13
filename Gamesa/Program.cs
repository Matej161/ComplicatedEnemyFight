using System;
using System.Threading.Channels;

namespace Gamesa;

public class Program
{
    public static void Main(string[] args)
    {
        Enemy oger = Enemy.Factory.CreateOger();
        Enemy goblin = Enemy.Factory.CreateGoblin();
        Player bob = Player.Factory.CreatePlayer();
        
        Random randomEnemy = new Random();
        
        Room room1 = new Room("bohate", false, false);
        Room room2 = new Room("prdel", false, false);
        
        bob.CurrentRoom = room1;

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("********************" + "\n" + " FUCKIN ELDEN RING " + "\n" + "********************" + "\n");
        Console.ForegroundColor = ConsoleColor.White;
        
        Console.ReadLine();

        Console.WriteLine("+-------+     +-------+     +-------+\n|       |     |       |     |       |\n| Start |-----| Díra  |-----| Mekáč |\n|       |     |       |     |       |\n+-------+     +-------+     +-------+\n     |                         |\n     |                         |\n+-------+                 +-------+\n|       |                 |       |\n| SPSMB |                 | Hajzl |\n|       |                 |       |\n+-------+                 +-------+\n");
        
        Console.ReadLine();

        Console.WriteLine("Vítej, odvážný hrdino! Tvá cesta začíná v nekde v prdeli idk, kde čeká mnoho nebezpečí. \n Podaří se ti porazit bosse a najít poklady, nebo padneš do temnoty?");
        
        Console.WriteLine("kam chces jit: \n 1.dira 2.spsmb");
        int num = Convert.ToInt32(Console.ReadLine());

        switch (num)
        {
            case 1: 
                bob.CurrentRoom = room1;
                Console.WriteLine("si tady ale co ted? \n 1.explorovat 2.zmlatit bluda");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1: room1.Explore();
                        break;
                    case 2: room2.StartBattle(bob, oger);
                        break;
                }
                break;
            case 2: 
                bob.CurrentRoom = room2;
                Console.WriteLine("si tady ale co ted? \n 1.explorovat 2.zmlatit vsechny");
                int action2 = Convert.ToInt32(Console.ReadLine());
                switch (action2)
                {
                    case 1: room1.Explore();
                        break;
                    case 2: room2.StartBattle(bob, oger);
                        break;
                    
                }
                break;
        }

    }
}