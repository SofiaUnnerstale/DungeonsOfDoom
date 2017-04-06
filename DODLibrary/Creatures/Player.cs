using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Creatures
{
   public class Player : Creature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<ICanBeCarried> Backpack { get; private set; }

        public Player(string name, int health, int strength, int x, int y, List<ICanBeCarried> backPack = null) : base(name, health, strength)
        {
            X = x;
            Y = y;

            if (backPack != null)
            {
                Backpack = backPack;
            }
            else
            {
                Backpack = new List<ICanBeCarried>();
            }
        }

        public Player(string name, int health, int strength, int x, int y, char icon, List<ICanBeCarried> backPack = null) : base(name, health, strength, icon)
        {
            X = x;
            Y = y;

            if (backPack != null)
            {
                Backpack = backPack;
            }
            else
            {
                Backpack = new List<ICanBeCarried>();
            }
            
        }

        public override int Attack(Creature creature)
        {

            creature.Health -= this.Strength;
            return this.Strength;
        }
    }

    
}
