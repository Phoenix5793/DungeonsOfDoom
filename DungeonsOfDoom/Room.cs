using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Room
    {
        public Room(int brightness)
        {
            Brightness = brightness;
        }
        public int Brightness { get; set; }
        public Item Loot { get; set; }
        public Monster RoomMonster { get; set; }        
        static public Room[,] Rooms { get; set; }
    }
}
