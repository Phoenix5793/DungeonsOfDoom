using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    class Elexir : Item, IConsumable
    {
        public Elexir(int health) : base("Elixir",0,health ,0,0,0)
        {

        }
    }
}
