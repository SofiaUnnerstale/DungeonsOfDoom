using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<Item> Backpack { get; private set; }

        public Player(string name, int health, int strength, int x, int y, List<Item> backPack = null) : base(name, health, strength)
        {
            X = x;
            Y = y;

            if (backPack != null)
            {
                Backpack = backPack;
            }
            else
            {
                Backpack = new List<Item>();
            }
        }

        public Player(string name, int health, int strength, int x, int y, char icon, List<Item> backPack = null) : base(name, health, strength, icon)
        {
            X = x;
            Y = y;

            if (backPack != null)
            {
                Backpack = backPack;
            }
            else
            {
                Backpack = new List<Item>();
            }
            
        }

        public override int Attack(Creature creature)
        {

            creature.Health -= this.Strength;
            return this.Strength;
        }
    }

    
}
