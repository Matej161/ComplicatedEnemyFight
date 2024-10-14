namespace Gamesa;
public class Enemy
{
    public string Name;
    public double BaseDmg;
    public double Hp;
    public bool IsLiving => Hp > 0;
    public bool IsDefeated { get; set; }

    public void Attack(Player target)
    {
        if (!IsLiving) return;
        target.Hp -= this.BaseDmg;
        Console.WriteLine(this.Name + " ti dal za  " + BaseDmg + " a ted mas " + target.Hp + " zivotu");
        
        if (this.Hp <= 0)
        {
            this.Hp = 0;
            IsDefeated = true;
        }
    }
    public Enemy(string name, double baseDmg, double hp)
    {
        this.Name = name;
        this.BaseDmg = baseDmg;
        this.Hp = hp;
        IsDefeated = false;
    }

    public static class Factory
    {
        public static Enemy CreateOger()
        {
            return new Enemy("Oger", 2, 10);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Goblin", 3, 10);
        }
    }
}