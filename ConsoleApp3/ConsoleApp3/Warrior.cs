using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Warrior: Person
    {
        protected int HP { get; set; }
        protected int maxHP { get; set; }
        protected int attack { get; set; }
        public Warrior(int x, int y)
        {
            HP = maxHP = 100;
            attack = 2;
            this.x = x;
            this.y = y;
        }
        public int x { get; private set; }
        public int y { get; private set; }
        static int edge = 0;
        public int MoveX(int left, int right)
        {
            if (edge%2==0)
            {
                x += 1;
                if (x == right) edge++;
                return x;
            }
            else
            {
                x -= 1;
                if (x == left) edge++;
                return x;
            }
        }
    }
}
