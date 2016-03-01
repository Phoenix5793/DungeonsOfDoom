using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Creature : GameObject
    {
        public Creature(string name, int health, int damage, int armor, int vision) : base(name, health, damage, armor, vision)
        {

        }
        public virtual string Fight(Creature creature)
        {
            creature.Health -= Math.Abs(this.Damage - creature.Armor);

            return "The Creature attacks you while utering a loud scream";
        }
    }
}
