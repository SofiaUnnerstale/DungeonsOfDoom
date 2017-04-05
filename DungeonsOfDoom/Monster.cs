using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : Creature
    {
        public string CatchPhrase { get; set; }

        public static int MonsterCount {get; set;}

        public Monster(string name, int health, string catchPhrase, int strength) : base(name, health, strength)
        {
            CatchPhrase = catchPhrase;
            MonsterCount++;
        }

        public Monster(string name, int health, string catchPhrase, int strength, char icon) : base(name, health, strength, icon)
        {
            CatchPhrase = catchPhrase;
            MonsterCount++;
        }
    }
}
