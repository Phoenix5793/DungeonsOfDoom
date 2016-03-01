using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    class Ogre : Monster
    {
        public Ogre(int health, int damage, int armor) : base("Ogre", health, damage, armor)
        {
        }
        public override string Fight(Creature player)
        {
            player.Health -= Damage / 2;
            return "The Creature attacks you while utering a loud scream";
        }
    }
}
