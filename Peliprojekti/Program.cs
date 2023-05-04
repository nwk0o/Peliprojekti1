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
            #region units
            List<Unit> Heroes = new List<Unit>();
            Heroes.Add(new Unit("Priestess", 15, 150, ConsoleColor.Blue));
            Heroes.Add(new Unit("Mage", 40, 100, ConsoleColor.Blue));
            Heroes.Add(new Unit("Martial Artist", 45, 80, ConsoleColor.Blue));
            Heroes.Add(new Unit("Hero", 50, 100, ConsoleColor.Blue));

            List<Unit> Demons = new List<Unit>();
            Demons.Add(new Unit("Rerzes", 30, 100, ConsoleColor.Magenta));
            Demons.Add(new Unit("Sengrillir", 25, 125, ConsoleColor.Magenta));
            Demons.Add(new Unit("Gorkamil", 20, 150, ConsoleColor.Magenta));
            Demons.Add(new Unit("Gozaxon", 15, 175, ConsoleColor.Magenta));
            #endregion
            #region beginning
            System.Random random = new System.Random();
            List<AttackAction> actions = new List<AttackAction>();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Battle begins." + "\n" + "\n" + "Player Army:");
            PrintHeroes(Heroes);
            Console.WriteLine("");
            Console.WriteLine("AI Army:");
            PrintHeroes(Demons);
            Console.WriteLine("");
            #endregion
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Player's turn. ");
                Console.WriteLine("Choose a unit by giving a number:");
                PrintHeroes(Heroes);
                int num1 = Choose(Heroes);
                if (num1 == -10)
                {
                    UndoAttack(actions);
                    UndoAttack(actions);
                    continue;
                }
                Console.WriteLine("Choose a target:");
                PrintHeroes(Demons);
                int num2 = Choose(Demons);
                if (num2 == -10)
                {
                    continue;
                }
                Attacking(Heroes, Demons, num1, num2);
                Unit attacker = Heroes[num1];
                Unit defender = Demons[num2];
                actions.Add(Attack(attacker, defender));
                if (Demons.Count == 0)
                {
                    ColorWheel("Congratulations. You win!", ConsoleColor.DarkYellow);
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine("AI's turn.");
                num1 = random.Next(0, Demons.Count);
                num2 = random.Next(0, Heroes.Count);
                Attacking(Demons, Heroes, num1, num2);
                attacker = Demons[num2];
                defender = Heroes[num1];
                actions.Add(Attack(attacker, defender));
                if (Heroes.Count == 0)
                {
                    ColorWheel("Unfortunately, You lose", ConsoleColor.DarkRed);
                    break;
                }
            }
        }

        static void PrintHeroes(List<Unit> army)
        {
            int i = 1;
            foreach (Unit u in army)
            {
                ColorWheel(Convert.ToString(i) + ": " + u.name + " ", u.color);
                ColorWheel("HP: " + Convert.ToString(u.hp) + " ", ConsoleColor.Green);
                ColorWheel("ATK: " + Convert.ToString(u.atk) + " ", ConsoleColor.Red);
                Console.WriteLine("");
                i++;
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ColorWheel(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Attacking(List<Unit> attacker, List<Unit> defender, int who1, int who2)
        {
            {
                ColorWheel(attacker[who1].name, attacker[who1].color);
                Console.Write(" attacks ");
                ColorWheel(defender[who2].name, defender[who2].color);
                Console.Write(", dealing ");
                ColorWheel(Convert.ToString(attacker[who1].atk), ConsoleColor.Red);
                Console.Write(" damage." + "\n");
            }
        }

        static int Choose(List<Unit> army)
        {
            while (true)
            {
                Console.WriteLine("Give a number:");
                string? input = Console.ReadLine();
                if (input == "z")
                {
                    return -10;
                }
                int num1 = -1;
                if (int.TryParse(input, out num1))
                {
                    if (army.Count >= num1)
                    {
                        num1--;
                        if (army[num1].hp <= 0)
                        {
                            Console.WriteLine("Only living beings can be selected!");
                        }
                        else
                        {
                            return num1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                }
            }
        }

        public static AttackAction Attack(Unit attacker, Unit defender)
        {
            defender.hp -= attacker.atk;
            if (defender.hp < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(attacker.name + " has killed " + defender.name + "." + "\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            AttackAction action = new AttackAction(attacker, defender);
            return action;
        }
        public static void UndoAttack(List<AttackAction> action)
        {
            if (action.Count > 0)
            {
                int lastAttack = action.Count - 1;
                AttackAction last = action[lastAttack];
                last.Undo();
                action.RemoveAt(lastAttack);
            }
        }

    }
}