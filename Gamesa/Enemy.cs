namespace Gamesa;
public class Enemy
{
    public string Name;
    public double BaseDmg;
    public double Hp;
    public bool IsLiving => Hp > 0;
    public Weapon DroppedWeapon { get; private set; }
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
    private Weapon GenerateWeapon()
    {
        Random rnd = new Random();
        int randomWeapon = rnd.Next(0, 3); 

        switch (randomWeapon)
        {
            case 0: return new Weapon("Sword", 12);
            case 1: return new Weapon("Axe", 10);
            case 2: return new Weapon("Dagger", 7);
            default: return new Weapon("Fists", 1); 
        }
    }
    public Enemy(string name, double baseDmg, double hp)
    {
        this.Name = name;
        this.BaseDmg = baseDmg;
        this.Hp = hp;
        IsDefeated = false;
        DroppedWeapon = GenerateWeapon();
    }

    public static class Factory
    {
        public static Enemy CreateOger()
        {
            return new Enemy("Oger", 1, 1);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Goblin", 1, 1);
        }
    }
}