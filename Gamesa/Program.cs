using System;
using System.Threading.Channels;

namespace Gamesa;

public class Program
{
    public List<Room> Rooms { get; private set; }
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(" DOBRÝ DEN\nJÁ VÁS VÍTÁM");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine("Zmáčkni enter ...");
        Console.ReadLine();
        Console.Clear();
            
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Vítej, odvážný hrdino! Tvá cesta začíná v nekde TADY, čeká tě mnoho nebezpečí. \nPodaří se ti porazit bosse a najít poklady, nebo padneš do temnoty?");
        Console.WriteLine();
        
        Player bob = Player.Factory.CreatePlayer();
        Rooms rooms = new Rooms();
        
        while (bob.IsLiving)
        {
            rooms.MainRoom(bob);
        }
        Console.ReadLine();
    }
}