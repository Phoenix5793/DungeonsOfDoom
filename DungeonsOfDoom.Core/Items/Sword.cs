using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Sword : Item
    {
        public Sword(int damage) : base("Sword", 6, 0, damage, 0, 0)
        {

        }
    }
}
