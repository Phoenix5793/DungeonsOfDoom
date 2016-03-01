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
       static public int RandomStat(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
        static public int Random(int value)
        {
            return random.Next(value);
        }
    }
}
