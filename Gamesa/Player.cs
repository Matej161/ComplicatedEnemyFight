using System.Collections;

namespace Gamesa;

public class Player
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
        Console.WriteLine("utocis na bluda a davas mu za " + BaseDmg + " a ted ma " + target.Hp + " zivotu");
        
        if (this.Hp <= 0)
        {
            this.Hp = 0;
        }
        
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
        Console.WriteLine($"You have equipped {weapon.Name}, damage: {weapon.Damage}");
    }
    
    public static class Factory
    {
        public static Player CreatePlayer()
        {
            return new Player(1, 10);
        }
    }

    public enum EHealPotions
    {
        naplast,
        bandaz,
        medkit
    }

    public enum EWeapons
    {
        knife,
        axe,
        sword
    }

    public void Heal(EHealPotions healPotions)
    {
        switch (healPotions)
        {
            case EHealPotions.naplast:
                Hp += 7;
                break;
            case EHealPotions.bandaz:
                Hp += 10;
                break;
            case EHealPotions.medkit:
                Hp += 15;
                break;
        }
    }

    public void Weapons(EWeapons Weapons)
    {
        switch (Weapons)
        {
            case EWeapons.knife:
                BaseDmg += 1;
                break;
            case EWeapons.axe:
                BaseDmg += 3;
                break;
            case EWeapons.sword:
                BaseDmg += 5;
                break;
        }
    }
}