using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    class Troll : Monster
    {
        public Troll(int health, int damage, int armor) : base("Troll", health, damage, armor)
        {
        }
    }
}
