using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliprojekti
{
    public class Unit
    {
        public string name { get; set; }
        public int atk { get; set; }
        public int hp { get; set; }
        public ConsoleColor color { get; set; }

        public Unit(string name, int atk, int hp, ConsoleColor color)
        {
            this.name = name;
            this.atk = atk;
            this.hp = hp;
            this.color = color;
        }
    }
}
