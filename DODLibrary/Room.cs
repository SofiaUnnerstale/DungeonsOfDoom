using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Items;
using DungeonsOfDoom.Creatures;

namespace DungeonsOfDoom
{
   public class Room
    {
        public Monster Monster { get; set; }        
        public Item Item { get; set; }              
    }
}
