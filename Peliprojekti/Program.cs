using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliprojekti
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit bard = new Unit("Bard", 25, 150);
            Unit mage = new Unit("Mage", 40, 100);

            Console.WriteLine("Battle begins. " + bard.name + " against " + mage.name);
            while (true)
            {
                Console.WriteLine(bard.name + " attacks " + mage.name + ", dealing " + bard.atk + " damage.");
                mage.hp = mage.hp - bard.atk;
                if(mage.hp == 0)
                {
                    Console.WriteLine(mage.name + " is defeated!");
                    Console.WriteLine(bard.name + " is victorious!");
                    break;
                }
                Console.WriteLine(mage.name + " attacks " + bard.name + ", dealing " + mage.atk + " damage.");
                bard.hp = bard.hp - mage.atk;
                if (bard.hp == 0)
                {
                    Console.WriteLine(bard.name + " is defeated!");
                    Console.WriteLine(mage.name + " is victorious!");
                    break;
                }
            }
        }
    }
}