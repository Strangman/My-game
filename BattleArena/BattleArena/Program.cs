using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    class Program
    {
        static void Main(string[] args)
        {
            Fist fists = new Fist();
            Names names = new Names();
            Player player = new Player(fists);
            Trader trader = new Trader(player);
            Console.WriteLine("What is your name, young gladiator?");
            player.setName(Console.ReadLine());
            
            for (; ; )
            {
                Console.Clear();
                player.getInfo();
                Console.WriteLine("What about some rest? It will be cost 5 coins(+20 HP)\n1.Yes\n2.No");
                if(Console.ReadLine() =="1")
                {
                    if (player.getMoney() >= 5)
                    {
                        player.setMoney(player.getMoney() - 5);
                        player.setHP(player.getHP() + 20);
                        if (player.getHP() > player.getMaxHP()) player.setHP(player.getMaxHP());
                    }
                    else
                    {
                        Console.Clear();
                        player.getInfo();
                        Console.WriteLine("You don't have enought money!");
                        Thread.Sleep(400);
                    }
                }
                else
                {
                    Console.Clear();
                    player.getInfo();
                    Console.WriteLine("Bye!");
                    Thread.Sleep(400);
                }
                Console.Clear();
                player.getInfo();
                trader.getTraid();
                Console.Clear();
                player.getInfo();
                Console.WriteLine("Do you want to fight?\n1.Yes\n2.No");
                if (Console.ReadLine() == "1")
                {
                    NPC npc = new NPC(fists);
                    npc.setName(names.getNames());
                    Battle battle = new Battle(player, npc);
                    battle.fight();
                    if (player.getHP() <= 0) break;
                    battle.raiseXP();
                    battle.raiseLvl();
                    battle.restoreStamina();
                    battle.giveMoney();
                }
                if (player.getHP() <= 0) break;
                Console.Clear();
                player.getInfo();
                Console.WriteLine("Do you want to continue?\n1.Yes\n2.No");
                if (Console.ReadLine() == "2") break;
            }
            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
    class Armor
    {
        protected string name;
        protected int defense;
        protected int price;
        public Armor()
        {
            name = "Armor";
            defense = 0;
            price = 0;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setDefence(int defense)
        {
            this.defense = defense;
        }
        public int getDefence()
        {
            return defense;
        }
        public int getPrice()
        {
            return price;
        }
    }
    class Rags : Armor
    {
        public Rags()
        {
            name = "Rags";
            defense = 3;
            price = 5;
        }
    }
    class Tunic : Armor
    {
        public Tunic()
        {
            name = "Tunic";
            defense = 7;
            price = 10;
        }
    }
    class Weapons
    {
        protected string name;
        protected int damage;
        protected int price;
        public Weapons()
        {
            name = "Weapon";
            damage = 0;
            price = 0;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setDamage(int damage)
        {
            this.damage = damage;
        }
        public int getDamage()
        {
            return damage;
        }
        public int getPrice()
        {
            return price;
        }
    }
    class Fist : Weapons
    {
        public Fist()
        {
            name = "Fist";
            damage = 1;
        }
    }
    class Knife : Weapons
    {
        public Knife()
        {
            name = "Knife";
            damage = 3;
            price = 5;
        }
    }
    class Sword : Weapons
    {
        public Sword()
        {
            name = "Sword";
            damage = 5;
            price = 10;
        }
    }
    class Names
    {
        Random ran = new Random();
        string[] names = { "Bob", "John", "Jack", "Ron", "Rick", "Vicktor", "Bilbo", "Daniel", "Boris","Ivan","Kolya" };
        public string getNames()
        {
            return names[ran.Next(0, names.Length - 1)];
        }
    }
    class Warior
    {
        protected string type;
        protected string name;
        protected double HP;
        protected double maxHP;
        protected int strength;
        protected double defens;
        protected double damage;
        protected int stamina;
        protected int maxStamina;
        protected int currentXP;
        protected int neededXP;
        protected int lvl;
        protected int money;
        Random rnd = new Random();
        protected Weapons weapon;
        protected Armor armor;
        public Warior(Weapons weapon)
        {
            HP = 100;
            maxHP = 100;
            strength = 5;
            defens = 3;
            stamina = 100;
            maxStamina = 100;
            neededXP = 20;
            lvl = 1;
            this.weapon = weapon;
            armor = new Armor();
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setHP(double HP)
        {
            this.HP = HP;
        }
        public double getHP()
        {
            return HP;
        }
        public void setMaxHP(double HP)
        {
            maxHP = HP;
        }
        public double getMaxHP()
        {
            return maxHP;
        }
        public void setStrength(int str)
        {
            strength = str;
        }
        public int getStrength()
        {
            return strength;
        }
        public void setStamina(int stamina)
        {
            this.stamina = stamina;
        }
        public int getStamina()
        {
            return stamina;
        }
        public void setMaxStamina(int maxStamina)
        {
            this.maxStamina = maxStamina;
        }
        public int getMaxStamina()
        {
            return maxStamina;
        }
        public void setDef(double def)
        {
            defens = def;
        }
        public double getDef()
        {
            return defens;
        }
        public double getAtack()
        {
            return damage;
        }
        public void setNeededXP(int xp)
        {
            neededXP = xp;
        }
        public int getNeededXp()
        {
            return neededXP;
        }
        public void setCurrentXP(int xp)
        {
            currentXP = xp;
        }
        public int getCurrentXp()
        {
            return currentXP;
        }
        public void setLvl(int lvl)
        {
            this.lvl = lvl;
        }
        public int getLvl()
        {
            return lvl;
        }
        public void setMoney(int money)
        {
            this.money = money;
        }
        public int getMoney()
        {
            return money;
        }
        public void setWeapon(Weapons weapon)
        {
            this.weapon = weapon;
        }
        public void setArmor(Armor armor)
        {
            this.armor = armor;
        }
        public void attackMove()
        {
            if (stamina >= 5)
            {
                if(type == "player") Console.WriteLine("1.Light Attack\n2.Heavy Attack\n3.Rest");
                switch (type == "player"? Console.ReadLine():Convert.ToString(rnd.Next(1,4)))
                {
                    case "1":
                        damage = ((strength + weapon.getDamage() )* 1)*(1-((defens + armor.getDefence()) * 0.01));
                        stamina -= 5;
                        break;
                    case "2":
                        if (stamina < 10)
                        {
                            Console.WriteLine("I'm tired");
                            Thread.Sleep(400);
                            break;
                        }
                        damage = ((strength + weapon.getDamage())* 1.85)*(1 - ((defens + armor.getDefence() )* 0.01));
                        stamina -= 10;
                        break;
                    case "3":
                        stamina += 4;
                        damage = 0;
                        break;
                }
            }
            else
            {
                Console.WriteLine("I'm tired");
                damage = 0;
                Thread.Sleep(400);
            }
            stamina += 3;
            if (stamina > 100) stamina -= stamina - 100;
        }
        public virtual void getInfo()
        {
            Console.Write("{0} HP: {1:#.##}/{2} Stamina: {3}/{4} Atck:{5} Def: {6}%",name, HP,maxHP, stamina,maxStamina,(strength + weapon.getDamage()), (defens + armor.getDefence()));
        }
    }
    class Player : Warior
    {
        public Player(Weapons weapon) :base(weapon)
        {
            type = "player";
            strength = 3;
            this.weapon = weapon;
        }
        public override void getInfo()
        {
            base.getInfo();
            Console.Write( " Lvl: {0} XP: {1}/{2} Money: {3}\n",lvl, currentXP, neededXP, money);
        }
    }
    class NPC : Warior
    {
        Random ran = new Random();
        public NPC(Weapons weapon) : base(weapon)
        {
            type = "npc";
            strength = ran.Next(2,6);
            HP = maxHP = ran.Next(80, 120);
            this.weapon = weapon;
        }
        public override void getInfo()
        {
            base.getInfo();
            Console.Write("\n");
        }
    }
    class Battle
    {
            Warior player;
            Warior npc;
            public Battle(Warior player, Warior npc)
            {
                this.player = player;
                this.npc = npc;
            }
            public void fight()
            {
                for (; ; )
                {
                    Console.Clear();
                    player.getInfo();
                    npc.getInfo();
                    player.attackMove();
                    npc.setHP(npc.getHP() - player.getAtack());
                    Console.Clear();
                    player.getInfo();
                    npc.getInfo();
                    if (npc.getHP() < 1)
                    {
                        Console.WriteLine("You win");
                        Console.ReadKey();
                        break;
                    }
                    Thread.Sleep(300);
                    npc.attackMove();
                    player.setHP(player.getHP() - npc.getAtack());
                    Console.Clear();
                    player.getInfo();
                    npc.getInfo();
                    if (player.getHP() < 1)
                    {
                        Console.WriteLine("You die");
                        Console.ReadKey();
                        break;
                    }
                    Thread.Sleep(400);
                }
            }
        public void raiseXP()
        {
            player.setCurrentXP(player.getCurrentXp()+10);
        }
        public void raiseLvl()
        {
            if (player.getCurrentXp()>=player.getNeededXp())
            {
                player.setLvl(player.getLvl()+1);
                player.setCurrentXP(player.getCurrentXp() - player.getNeededXp());
                player.setNeededXP(player.getNeededXp() * 2);
                player.setMaxHP(player.getMaxHP()+15);
                player.setMaxStamina(player.getMaxStamina() + 15);
                player.setStrength(player.getStrength()+3);
            }
        }
        public void restorePlayer()
        {
            player.setHP(player.getMaxHP());
            player.setStamina(player.getMaxStamina());
        }
        public void restoreStamina()
        {
            player.setStamina(player.getMaxStamina());
        }
        public void giveMoney()
        {
            player.setMoney(player.getMoney() + 10);
        }
    }
    class Trader
    {
        Knife knife = new Knife();
        Sword sword = new Sword();
        Rags rags = new Rags();
        Tunic tunic = new Tunic();
        Warior warior;
        public Trader(Warior warior)
        {
            this.warior = warior;
        }
        public void getTraid()
        {
            Console.Clear();
            warior.getInfo();
            Console.WriteLine("What do you want to buy:\n1.{0}({1} coins)\n2.{2}({3} coins)\n3.{4}({5} coins)\n4.{6}({7} coins)\n5.No",knife.getName(), knife.getPrice(), sword.getName(), 
                sword.getPrice(), rags.getName(),rags.getPrice(),tunic.getName(),tunic.getPrice());
            switch (Console.ReadLine())
            {
                case"1":
                    if (warior.getMoney()>=knife.getPrice())
                    {
                        warior.setWeapon(knife);
                        warior.setMoney(warior.getMoney()-knife.getPrice());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enought money!!");
                        Console.ReadKey();
                    }
                    break;
                case "2":
                    if (warior.getMoney() >= sword.getPrice())
                    {
                        warior.setWeapon(sword);
                        warior.setMoney(warior.getMoney() - sword.getPrice());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enought money!!");
                        Console.ReadKey();
                    }
                    break;
                case "3":
                    if (warior.getMoney() >= rags.getPrice())
                    {
                        warior.setArmor(rags);
                        warior.setMoney(warior.getMoney() - rags.getPrice());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enought money!!");
                        Console.ReadKey();
                    }
                    break;
                case "4":
                    if (warior.getMoney() >= tunic.getPrice())
                    {
                        warior.setArmor(tunic);
                        warior.setMoney(warior.getMoney() - tunic.getPrice());
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enought money!!");
                        Console.ReadKey();
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Bye");
                    Console.ReadKey();
                    break;
            }
        }
    }
}