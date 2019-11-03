using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Player:Person
    {
        protected int HP { get; set; }
        protected int maxHP { get; set; }
        protected int attack { get; set; }
        public Player()
        {
            HP = maxHP = 3;
            attack = 2;
        }
        public void setHP(int HP)
        {
            this.HP = HP;
        }
        public int getHP()
        {
            return HP;
        }
    }
}
