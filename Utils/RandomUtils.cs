using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
   public static class RandomUtils
    {
       static Random random = new Random();

        static public bool RandomLike(int seed, int percentage)
        {
            int randomNumber = Math.Abs(seed.ToString().GetHashCode()) % 100;
            return randomNumber < percentage;
        }

        static public int RandomGenerator ()
        {
            int randomNumber = random.Next(0, 101);

            return randomNumber;
        }

        static public bool RandomGenerator(int upperLimit)
        {
           
            int randomNumber = random.Next(0, 101);
            if (randomNumber <= upperLimit)
            {
                return true;
            }
            else
                return false;

        }
    }
}
