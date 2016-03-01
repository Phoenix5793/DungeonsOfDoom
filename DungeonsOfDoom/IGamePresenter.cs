using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IGamePresenter
    {
        void DisplayWorld(Player player);
        void DisplayPlayerInfo(Player player, int monsterCount);
        void WelcomeScreen();
        string EnterName();
        void Movement();
        void Clear();
        void Incorrect();
        void PickUp(Player player);
        void Encounter(Monster roomMonster);
        void Blind();
        void NameCheck();
        void Consume(Item consumable);
    }
}
