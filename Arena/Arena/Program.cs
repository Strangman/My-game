using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Human pers = new Human();
            Human npc = new Human();
            Names names = new Names();
            Console.Write("Enter plater name: ");
            pers.setName(Console.ReadLine());
            npc.setName(names.getNames());
            for (; ; )
            {
                Console.WriteLine(pers.getName() +" HP: " + pers.getHP() + " Stamina: " + pers.getStamina() + "\n" + npc.getName() + " HP: " + npc.getHP() + " Stamina: " + npc.getStamina());
                Console.WriteLine("1.Light Attack\n2.Heavy Attack");
                switch (Console.ReadLine())
                {
                    case "1":
                        pers.lightStrike();
                        break;
                    case "2":
                        pers.heavyAttack();
                        break;
                    default:
                        pers.skipTurn();
                        break;
                }
                npc.attackHP(pers.getAttack());
                if (npc.getHP() <= 0)
                {
                    Console.WriteLine("You win!!");
                    break;
                }
                switch (rnd.Next(0,2))
                {
                    case 1:
                        npc.lightStrike();
                        break;
                    case 0:
                        npc.heavyAttack();
                        break;
                }

                pers.attackHP(npc.getAttack());
                if (pers.getHP() <= 0)
                {
                    Console.WriteLine("You die");
                    break;
                }
                pers.endTurn();
                npc.endTurn();
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
    class Names
    {
        Random ran = new Random();
        string[] names = { "John", "Bob", "Jack", "Ron"};
        public string getNames()
        {
            return names[ran.Next(0,4)];
        }
    }
    class Human
    {
        private string name;
        private double HP = 100;
        private int power = 2;
        private int stamina = 100;
        private double attack;
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public double getHP()
        {
            return HP;
        }
        public int getStamina()
        {
            return stamina;
        }
        public void attackHP(double attack)
        {
            HP -= attack;
        }
        public double getAttack()
        {
            return attack;
        }
        public void lightStrike()
        {
            if (stamina < 5)
            {
                attack = 0;
                stamina -= 0;
            }
            else
            {
                attack = power * 1;
                stamina -= 5;
            }
        }
        public void heavyAttack()
        {
            if (stamina < 10)
            {
                attack = 0;
                stamina -= 0;
            }
            else
            {
                attack = power * 1.75;
                stamina -= 10;
            }
        }
        public void skipTurn()
        {
            attack = 0;
            stamina -= 0;
        }
        public void endTurn()
        {
            if (stamina == 100 || stamina >97)
            {
                stamina += 0;
            }
            else
            {
                stamina += 3;
            }
        }
    }
    class Player: Human
    {

    }
}
