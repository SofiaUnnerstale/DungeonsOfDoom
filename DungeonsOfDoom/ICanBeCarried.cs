﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface ICanBeCarried
    {
        int Weight { get; }
        string Name { get; }
    }
}
