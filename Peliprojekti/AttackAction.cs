using Peliprojekti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliprojekti
{
    internal class AttackAction
    {
        public Unit attacker;
        public Unit defender;


        public AttackAction(Unit attacker, Unit defender)
        {
            this.attacker = attacker;
            this.defender = defender;
        }

        public void Undo()
        {
            defender.hp += attacker.atk;
        }
    }

}