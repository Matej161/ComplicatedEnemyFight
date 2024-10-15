using System.Collections;

namespace Gamesa;

public partial class Player
{
    internal int BaseDmg;
    internal double Hp;
    internal bool IsLiving => Hp > 0;
    public Room CurrentRoom { get; set; }
    public Weapon EquippedWeapon { get; private set; }
    
    public Inventory PlayerInventory { get; private set; }

    public void Attack(Enemy target)
    {
        if (!IsLiving) return;
        int damage = EquippedWeapon != null ? EquippedWeapon.Damage : BaseDmg;
        target.Hp -= this.BaseDmg;
        if (target.Hp <= 0)
        {
            target.Hp = 0;
        }
        Console.WriteLine($"útočíš na {target.Name} a dáváš mu za " + BaseDmg + " damage a teď má " + target.Hp + " životů.");
    }

    public Player(int baseDmg, double hp)
    {
        BaseDmg = baseDmg;
        Hp = hp;
        PlayerInventory = new Inventory();
        EquippedWeapon = new Weapon("Fists", BaseDmg);
    }
    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        BaseDmg = weapon.Damage;
        Console.WriteLine($"Používáš {weapon.Name}, damage: {weapon.Damage}");
    }

    public void ShowStats(Player player)
    {
        Console.WriteLine($"Hp: {player.Hp}");
        Console.WriteLine($"Damage: {player.BaseDmg}");
        Console.WriteLine($"Zbraň: {player.EquippedWeapon.Name}");
        Console.WriteLine();
    }
    
    public static class Factory
    {
        public static Player CreatePlayer()
        {
            return new Player(5, 10);
        }
    }

    public void Heal(EHealPotions healPotions)
    {
        switch (healPotions)
        {
            case EHealPotions.náplast:
                Hp += 7;
                break;
            case EHealPotions.bandáž:
                Hp += 10;
                break;
            case EHealPotions.medkit:
                Hp += 15;
                break;
        }
    }
}