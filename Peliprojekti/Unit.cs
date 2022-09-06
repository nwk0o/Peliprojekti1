using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliprojekti
{
    public class Unit
    {
        public string name;
        public int atk;
        public int hp;

        public Unit(string name, int atk, int hp)
        {
            this.name = name;
            this.atk = atk;
            this.hp = hp;
        }
        
        public void PrintUnit()
        {
            Console.WriteLine(this.name + ", " + this.atk + ", " + this.hp);
        }
    }
}
