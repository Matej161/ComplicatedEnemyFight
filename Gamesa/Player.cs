using System.Collections;

namespace Gamesa;

public class Player
{
    internal double BaseDmg;
    internal double Hp;
    internal bool IsLiving => Hp > 0;
    public Room CurrentRoom { get; set; }
    
    public Inventory PlayerInventory { get; private set; }

    public void Attack(Enemy target)
    {
        if (!IsLiving) return;
        target.Hp -= this.BaseDmg;
        Console.WriteLine("utocis na bluda a davas mu za " + BaseDmg + " a ted ma " + target.Hp + " zivotu");
        
        if (this.Hp <= 0)
        {
            this.Hp = 0;
        }
        
    }

    public Player(double baseDmg, double hp)
    {
        BaseDmg = baseDmg;
        Hp = hp;
        PlayerInventory = new Inventory();
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

    public enum EStrengthPotions
    {
        small,
        medium,
        large
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

    public void IncreaseDamage(EStrengthPotions strengthPotions)
    {
        switch (strengthPotions)
        {
            case EStrengthPotions.small:
                BaseDmg += 1;
                break;
            case EStrengthPotions.medium:
                BaseDmg += 3;
                break;
            case EStrengthPotions.large:
                BaseDmg += 5;
                break;
        }
    }
}