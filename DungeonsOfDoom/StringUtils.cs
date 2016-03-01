using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    static class StringUtils
    {
        //static Marquee marquee = new Marquee();
        public static void Marquee(string value)
        {
            foreach (char c in value)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
    }
}
