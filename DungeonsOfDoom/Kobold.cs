using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Kobold : Monster
    {
        public Kobold(int health, int damage, int armor) : base("Kobold", health, damage, armor)
        {
        }
        public override string Fight(Creature creature)
        {
            if (creature.Damage > this.Damage * 2)
            {
                this.Health = 0;
                return "The Kobold panics at your power and dies";
            }
            else
            {
                string result = base.Fight(creature);
                return result;
            }
        }
    }
}
