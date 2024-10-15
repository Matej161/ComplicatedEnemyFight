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
        target.Hp = Math.Max(0, target.Hp - BaseDmg);
        IsDefeated = Hp <= 0;
        Console.WriteLine(this.Name + " tě udeřil za " + BaseDmg + " damage a teď máš " + target.Hp + " životů");
    }
    private Weapon GenerateWeapon()
    {
        Random rnd = new Random();
        int randomWeapon = rnd.Next(0, 3); 

        switch (randomWeapon)
        {
            case 0: return new Weapon("Meč", 12);
            case 1: return new Weapon("Sekera", 10);
            case 2: return new Weapon("Nožík", 7);
            default: return new Weapon("Pěsti", 1); 
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
            return new Enemy("Oger", 4, 12);
        }

        public static Enemy CreateGoblin()
        {
            return new Enemy("Goblin", 2, 6);
        }
        
        public static Enemy CreateSkeleton()
        {
            return new Enemy("Skeleton", 6, 9);
        }
        
        public static Enemy CreateSpider()
        {
            return new Enemy("Spider", 5, 10);
        }
        
        public static Enemy CreateZombie()
        {
            return new Enemy("Zombie", 3, 13);
        }
        public static Enemy CreateUrban()
        {
            return new Enemy("Urban", 1, 20);
        }
        public static Enemy CreateBohata()
        {
            return new Enemy("Boss", 5, 40);
        }
    }
}