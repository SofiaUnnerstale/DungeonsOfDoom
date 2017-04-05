using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Grimsnare : Monster
    {
        public Grimsnare() : base("Grimsnare", 30, "Bu!", 5, '*')
        {

        }

        public override void Attack(Creature creature)
        {
            creature.Health -= this.Strength;
        }
    }
}

