﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
   public static class TextUtils
    {
        public static void AnimateText(string text, int delay)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                Thread.Sleep(delay);
            }
        }
    }
}
