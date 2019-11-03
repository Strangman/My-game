using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = 10;
            string[][] grass = new string[range][];
            Player player = new Player();
            Warrior warrior = new Warrior(5,3);
            for(int i =0; i< grass.Length; i++)
            {
                grass[i] = new string[range];
            }

            for (int i = 0; i < grass.Length; i++)
            {
                for (int j = 0; j < grass[i].Length; j++)
                {
                    grass[i][j] = "_";
                }
            }
            string q = "";
            int x = 0;
            int y = 0;
            grass[0][0] = "A";
            grass[3][2] = "T";
            grass[5][6] = "T";
            grass[7][3] = "T";
            grass[warrior.y][warrior.x] = "X";
            for (; ; )
            {
                for (int i=0; i<grass.Length;i++)
                {
                    for(int j=0; j<grass[i].Length;j++)
                    {
                        Console.Write(grass[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"HP: {player.getHP()}");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        Console.Clear();
                        if (grass[y - 1][x] == "T")
                        {
                            continue;
                        }
                        else if (grass[y - 1][x] == "X")
                        {
                            player.setHP(player.getHP()-1);
                        }
                        else
                        {
                            y--;
                            q = grass[y][x];
                            grass[y][x] = grass[y + 1][x];
                            grass[y + 1][x] = q;
                        }
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        if (grass[y + 1][x] == "T")
                        {
                            continue;
                        }
                        else if (grass[y + 1][x] == "X")
                        {
                            player.setHP(player.getHP() - 1);
                        }
                        else
                        {
                            y++;
                            q = grass[y][x];
                            grass[y][x] = grass[y - 1][x];
                            grass[y - 1][x] = q;
                        }
                        break;
                    case ConsoleKey.A:
                        Console.Clear();
                        if (grass[y][x-1] == "T")
                        {
                            continue;
                        }
                        else if (grass[y][x - 1] == "X")
                        {
                            player.setHP(player.getHP() - 1);
                        }
                        else
                        {
                            x--;
                            q = grass[y][x];
                            grass[y][x] = grass[y][x + 1];
                            grass[y][x + 1] = q;
                        }
                        break;
                    case ConsoleKey.D:
                        Console.Clear();
                        if (grass[y][x + 1] == "T")
                        {
                            continue;
                        }
                        else if (grass[y][x + 1] == "X")
                        {
                            player.setHP(player.getHP() - 1);
                        }
                        else
                        {
                            x++;
                            q = grass[y][x];
                            grass[y][x] = grass[y][x - 1];
                            grass[y][x - 1] = q;
                        }
                        break;
                }
                if (grass[grass.Length - 1][grass.Length - 1] == "A" || player.getHP()<0) break;
                string w = "";
                w = grass[warrior.y][warrior.x];
                grass[warrior.y][warrior.x] = grass[warrior.y][warrior.MoveX(0,grass.Length-1)];
                grass[warrior.y][warrior.x] = w;
            }
            if (player.getHP() <= 0)
            {
                Console.WriteLine("Lose");
            }
            else
            {
                Console.WriteLine("WIN");
            }
            Console.ReadKey();
        }
    }
}
