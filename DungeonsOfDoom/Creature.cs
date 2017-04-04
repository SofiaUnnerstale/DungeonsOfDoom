using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Creature : GameObject
    {
        public int Health { get; set; }
        public int Strength { get; set; }

        public Creature(string name, int health, int strength) : base(name)
        {
            Health = health;
            Strength = strength;
        }

        public Creature(string name, int health, int strength, char icon) : base(name, icon)
        {
            Health = health;
            Strength = strength;
        }
    }
}
