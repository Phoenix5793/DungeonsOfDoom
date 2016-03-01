using DungeonsOfDoom.Core.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom.Core
{
   public class StandardDisplay : IGamePresenter
    {
        public void WelcomeScreen()
        {
            Console.Title = "Dungeons of doom";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " XXXXXXXXXXXXXXXX "));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", " Dungeons of doom "));
            Console.WriteLine(string.Format("{0," + Console.WindowWidth / 2 + "}", " XXXXXXXXXXXXXXXX "));
            Console.Title = "Dungeons of doom";
        }

        public void Consume(Item consumable)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"you found a {consumable.Name} and consumed it");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void DisplayWorld(Player player)
        {
            for (int y = 0; y < Game.worldHeight; y++)
            {
                for (int x = 0; x < Game.worldWidth; x++)
                {
                    if (y == player.Y && x == player.X)
                    {
                        Player(player);
                    }
                    else if (Room.Rooms[x, y].RoomMonster != null)
                    {
                        Monster();
                    }
                    else if (Room.Rooms[x, y].Loot != null)
                    {
                        Loot();
                    }
                    else
                    {
                        EmptyRoom();
                    }
                }
                Space();
            }
        }
        public void DisplayPlayerInfo(Player player, int monsterCount)
        {
            Console.WriteLine($"Name:{ player.Name}");
            Console.WriteLine($"Position:{ player.X} {player.Y}");
            Console.WriteLine($"Health:{ player.Health}");
            Console.WriteLine($"Vision:{ player.Vision}");
            Console.WriteLine($"Damage:{ player.Damage}");
            Console.WriteLine($"Armor:{ player.Armor}");
            Console.WriteLine($"Nr Of Monsters {monsterCount}");
            foreach (Item item in player.Backpack)
            {
                Console.Write(item.Name + " ");
            }
            Console.WriteLine($"\nEncumberance:{player.Encumbrance}");
        }

        public void Player(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{" + player.Name[0].ToString().ToUpper() + "}");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Monster()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{!}");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Loot()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{$}");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void EmptyRoom()
        {
            Console.Write("{ }");
        }

        public void Space()
        {
            Console.WriteLine();
        }
        public string EnterName()
        {
            StringUtils.Marquee("Please enter your name:");
            return Console.ReadLine().ToLower();
        }
        public void Movement()
        {
            Console.WriteLine("Enter your movment");
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Incorrect()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Incorrect input please use the arrowkeys");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void PickUp(Player player)
        {
            Console.WriteLine($"You found {Room.Rooms[player.X, player.Y].Loot.Name}");
        }

        public void Encounter(Monster monster)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You see a {monster.Name} with  health: {monster.Health} and you attack it");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void Blind()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You feel a presence in the room, and suddenly you get sent flying back to where you came from");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        public void NameCheck()
        {
            
            Console.WriteLine ("Hey! Your name is to short!");
        }
    }
}
