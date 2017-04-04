using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Food : Item
    {
        public int Health { get; set; }

        public Food(string name, int weight, int health) : base(name, weight)
        {
            Health = health;
        }

        public Food(string name, int weight, int health, char icon) : base(name, weight, icon)
        {
            Health = health;
        }

    }
}
