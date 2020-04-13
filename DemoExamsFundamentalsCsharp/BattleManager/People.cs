using System;
using System.Collections.Generic;
using System.Text;

namespace BattleManager
{
    public class People
    {
        public int Health { get; set; }
        public int Energy { get; set; }

        public People(int health, int energy)
        {
            this.Health = health;
            this.Energy = energy;
        }
    }
}
