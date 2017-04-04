using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class GameObject
    {
        public string Name { get; set; }
        public char Icon { get; set; }


        public GameObject(string name)
        {
            Name = name;
            Icon = Name.ToUpper()[0];
        }

        public GameObject(string name, char icon)
        {
            Name = name;
            Icon = icon;
        }

    }
    
}

