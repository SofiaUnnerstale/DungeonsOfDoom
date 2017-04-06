using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item, ICanBeCarried
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
        
        public override void PickUpItem(Player player)
        {
            player.Backpack.Add(this);
            UseItem(player);
        }

        private void UseItem(Player player)
        {
            //TODO Använda vapen måste läggas till i Game.cs
            player.Strength += this.Strength;
        }


    }
}
