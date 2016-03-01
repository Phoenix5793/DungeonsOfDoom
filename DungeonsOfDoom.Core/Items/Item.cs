using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.Items
{
    public class Item : GameObject
    {
        internal Item(string name, int weight, int health, int damage, int armor, int vision) : base(name, health, damage, armor, vision)
        {

            Weight = weight;

        }
        public int Weight { get; set; }
    }
}
