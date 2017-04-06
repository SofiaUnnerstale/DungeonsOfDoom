using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Grimsnare : Monster
    {
        public Grimsnare() : base("Grimsnare", 1, "Bu!", 5, '*')
        {

        }

        public override int Attack(Creature creature)
        {
            creature.Health -= this.Strength;
            return this.Strength;
        }
    }
}

