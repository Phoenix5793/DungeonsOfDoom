using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core
{
    public abstract class GameObject
    {
        internal GameObject(string name, int health, int damage, int armor, int vision)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
            Vision = vision;
        }
        public string Name { get; set; }
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }
        public int Damage { get; set; }
        public int Armor { get; set; }
        public int Vision { get; set; }
    }
}
