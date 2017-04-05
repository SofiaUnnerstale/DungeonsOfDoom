using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public int Strength { get; set; }

        public Weapon(string name, int weight, int strength) : base(name, weight)
        {
            Strength = strength;
        }

        public Weapon(string name, int weight, int strength, char icon) : base(name, weight, icon)
        {
            Strength = strength;
        }
        //TODO
        public override void PickUpItem(Player player)
        {
            player.Backpack.Add(this);
            
        }
    }
}
