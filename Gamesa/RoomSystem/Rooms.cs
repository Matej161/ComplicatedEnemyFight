namespace Gamesa;

public class Rooms
{
    public List<Room> RoomList { get; private set; }

    public Rooms()
    {
        RoomList = new List<Room>
        {
            new Room("dira", true, false),
            new Room("spsmb", false, false),
            new Room("spawn", true, false),
            new Room("McDonalds", false, false),
            new Room("Předsíň", false, false),
            new Room("Ústav", false, false),
            new Room("Boss", true, true)
        };
    }

    public Room GetRoom(int index)
    {
        return RoomList[index];
    }

    public void MainRoom(Player bob)
    {
        bool exitRoom = false;

        while (!exitRoom)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Kam se vydáš? \n1.Díra 2.SPSMB 3.McDonalds 4.Předsíň 5.Ústav 6.Štěpánka");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (num)
            {
                case 1:
                    bob.CurrentRoom = GetRoom(0);
                    break;
                case 2:
                    bob.CurrentRoom = GetRoom(1);
                    break;
                case 3:
                    bob.CurrentRoom = GetRoom(2);
                    break;
                case 4:
                    bob.CurrentRoom = GetRoom(3);
                    break;
                case 5:
                    bob.CurrentRoom = GetRoom(4);
                    break; 
                case 6:
                    bob.CurrentRoom = GetRoom(5);
                    break; 
                default:
                    Console.WriteLine("Neplatná volba.");
                    continue;
            }

            bob.CurrentRoom.Yapping();
            exitRoom = bob.CurrentRoom.Explore(bob);
        }
    }
}