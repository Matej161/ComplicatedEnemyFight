namespace Gamesa;

public class Inventory
{
    private List<Player.EHealPotions> potions;

    public Inventory()
    {
        potions = new List<Player.EHealPotions>();
    }

    public void AddPotion(Player.EHealPotions potion)
    {
        potions.Add(potion);
        Console.WriteLine($"+ 1 {potion}");
    }

    public void UsePotion(Player player)
    {
        if (potions.Count == 0)
        {
            Console.WriteLine("Nemáš žádné healy v inventáři.");
            return;
        }

        Console.WriteLine("Vyber heal k použití:");
        for (int i = 0; i < potions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {potions[i]}");
        }

        int choice = Convert.ToInt32(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < potions.Count)
        {
            player.Heal(potions[choice]);
            Console.WriteLine($"{potions[choice]} byla použita.");
            potions.RemoveAt(choice);
        }
        else
        {
            Console.WriteLine("Neplatná volba.");
        }
    }

    public void ShowPotions()
    {
        if (potions.Count == 0)
        {
            Console.WriteLine("Inventář je prázdný.");
            return;
        }

        Console.WriteLine("Healy v inventáři:");
        foreach (var potion in potions)
        {
            Console.WriteLine(potion);
        }
    }
}