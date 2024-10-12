namespace Gamesa;
public class Enemy
{
    internal string Name;
    internal double BaseDmg;
    internal double Hp;
    internal bool IsLiving = true;

    public void Attack(Player target)
    {
        if (this.Hp <= 0)
        {
            this.Hp = 0;
            IsLiving = false;
        }
        
        target.Hp -= this.BaseDmg;
        Console.WriteLine(this.Name + " ti dal za  " + BaseDmg + " a ted mas " + target.Hp + " zivotu");
    }
    public Enemy(string name, double baseDmg, double hp, bool isLiving = true)
    {
        this.Name = name;
        this.BaseDmg = baseDmg;
        this.Hp = hp;
        IsLiving = isLiving;
    }

    public static class Factory
    {
        public static Enemy CreateOger()
        {
            return new Enemy("Oger", 5, 50, true);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Goblin", 1, 20);
        }
    }
}