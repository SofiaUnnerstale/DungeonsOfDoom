using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class PrimitivePhantomBeast : Monster
    {
        public PrimitivePhantomBeast() : base("Primitive Phantom Beast", 1, "Prepare to die!", 3, '*')
        {

        }

        public override int Attack(Creature creature)
        {
            if (this.Strength*2 > creature.Strength)
            {
                creature.Health -= this.Strength;
                return this.Strength;
            }
            else
            { 
                this.Health = 0;
                return 0;
            }

        }

    }

}
