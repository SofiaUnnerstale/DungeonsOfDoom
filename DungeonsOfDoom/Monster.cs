using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Monster : Creature
    {
        public string CatchPhrase { get; set; }

        public Monster(string name, int health, string catchPhrase, int strength) : base(name, health, strength)
        {
            CatchPhrase = catchPhrase;
        }

        public Monster(string name, int health, string catchPhrase, int strength, char icon) : base(name, health, strength, icon)
        {
            CatchPhrase = catchPhrase;
        }
    }
}
