using System.Collections;

namespace Gamesa;

public class Player
{
    internal double BaseDmg;
    internal double Hp;
    internal bool IsLiving = true;
    public Room CurrentRoom { get; set; }

    public void Attack(Enemy target)
    {
        if (this.Hp <= 0)
        {
            this.Hp = 0;
            IsLiving = false;
        }
        
        target.Hp -= this.BaseDmg;
        Console.WriteLine("utocis na bluda a davas mu za " + BaseDmg + " a ted ma " + target.Hp + " zivotu");
    }

    public Player(double baseDmg, double hp, bool isLiving)
    {
        BaseDmg = baseDmg;
        Hp = hp;
        IsLiving = isLiving;
    }

    public static class Factory
    {
        public static Player CreatePlayer()
        {
            return new Player(2, 10, true);
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