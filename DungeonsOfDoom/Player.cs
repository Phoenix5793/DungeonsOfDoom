using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Creature//Arv av Creature
    {
        public Player(string name, int health, int vision, int damage, int armor) : base(name, health, damage, armor, vision)
        {
            Backpack = new List<Item>();
            if (name.Length < 2)
            {
                throw new ArgumentException("Invalid name");                    
            }
        }
        public List<Item> Backpack { get; set; }
        public int Encumbrance { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
