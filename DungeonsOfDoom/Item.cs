﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject            
    {
        public int Weight { get; set; }

        public Item(string name, int weight) : base(name)
        {
            Weight = weight;
        }

        public Item(string name, int weight, char icon) : base(name, icon)
        {
            Weight = weight;
        }
    }
}
