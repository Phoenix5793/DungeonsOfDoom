using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Bread : Item, IConsumable
    {
        public Bread(int health) : base("Bread",0,health,0,0,0)
        {

        }
    }
}
