using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class PrimitivePhantomBeast : Monster
    {
        public PrimitivePhantomBeast() : base("Primitive Phantom Beast", 15, "Prepare to die!", 3, '*')
        {

        }

        public override void Attack(Creature creature)
        {
            creature.Health -= this.Strength;
        }

    }
   
}
