using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
   public abstract class Monster : Creature//Arv av Creature
    {
        internal Monster(string name, int health, int damage, int armor) : base(name, health, damage, armor, 100)
        {
        }
    }
}
