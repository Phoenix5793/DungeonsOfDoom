using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        IGamePresenter presenter;
        public static int worldWidth;
        public static int worldHeight;
        int monsterCount;
        public Game(IGamePresenter presenter)
        {
            this.presenter = presenter;
        }
        public void Start()
        {

            presenter.WelcomeScreen();

            CreatePlayer();
            CreateRooms();
            do
            {
                presenter.DisplayPlayerInfo(player, monsterCount);
                presenter.DisplayWorld(player);
                AskForCommand();
                if (monsterCount == 0)
                {
                    newLevel();
                }

            } while (player.Health > 0);
        }

        private void newLevel()
        {
            presenter.Clear();
            player.X = 0;
            player.Y = 0;
            CreateRooms();
        }

        void CreateRooms()
        {
            worldWidth = RandomUtils.RandomStat(9, 16);
            worldHeight = RandomUtils.RandomStat(9, 16);

            //Skapar en tvådimensionell array för våra rum
            Room.Rooms = new Room[worldWidth, worldHeight];
            //Skapa rummen
            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    Room.Rooms[x, y] = new Room(RandomUtils.Random(100));

                    if (RandomUtils.Random(100 + 1) < 10 && Room.Rooms[x, y] != Room.Rooms[0, 0])
                    {
                        Room.Rooms[x, y].Loot = CreateItem(RandomUtils.Random(8 + 1));
                    }

                    if (RandomUtils.Random(100 + 1) < 15 && Room.Rooms[x, y] != Room.Rooms[0, 0])
                    {
                        Room.Rooms[x, y].RoomMonster = CreateMonster();
                        monsterCount++;
                    }
                }
            }
            Room.Rooms[RandomUtils.Random(worldWidth), RandomUtils.Random(worldHeight)].Loot = new Item("Torch", 0, 0, 0, 0, 100);
        }

        Item CreateItem(int itemNumber)
        {
            Item item = null;
            switch (itemNumber)
            {
                case 1:
                    item = new Sheild(RandomUtils.RandomStat(1, 5));
                    break;
                case 2:
                    item = new Sword(RandomUtils.RandomStat(1, 9));
                    break;
                case 3:
                    item = new Helmet(RandomUtils.RandomStat(1, 5));
                    break;
                case 4:
                    item = new Breastplate(RandomUtils.RandomStat(3, 9));
                    break;
                case 5:
                    item = new Flail(RandomUtils.RandomStat(3, 10));
                    break;
                case 6:
                    item = new Elexir(RandomUtils.RandomStat(15, 35));
                    break;
                case 7:
                    item = new Bread(RandomUtils.RandomStat(5, 15));
                    break;
                case 8:
                    item = new Redbull();
                    break;
            }
            return item;
        }
        Monster CreateMonster()
        {
            Monster monster = null;
            switch (RandomUtils.RandomStat(1, 5))
            {
                case 1:
                    monster = new Troll(RandomUtils.RandomStat(20, 60), RandomUtils.RandomStat(10, 15), RandomUtils.Random(3));
                    break;
                case 2:
                    monster = new Ogre(RandomUtils.RandomStat(30, 70), 12, RandomUtils.RandomStat(3, 8));
                    break;
                case 3:
                    monster = new Gnoll(RandomUtils.RandomStat(15, 35), RandomUtils.RandomStat(10, 15), 5);
                    break;
                case 4:
                    monster = new Kobold(RandomUtils.RandomStat(10, 20), RandomUtils.Random(5 + 1), 2);
                    break;
            }
            return monster;
        }
        void CreatePlayer()
        {
            bool allowedName = false;
            string playerName;
            do
            {
                playerName = presenter.EnterName();
                if (String.IsNullOrWhiteSpace(playerName))
                {
                    playerName = "Boris";
                    allowedName = true;
                }

                else if (playerName.Length < 2)
                {
                    presenter.NameCheck();
                }

                else
                    allowedName = true;

            } while (allowedName == false);

            presenter.Clear();

            player = new Player(playerName, RandomUtils.RandomStat(30, 60), RandomUtils.RandomStat(50, 101),
            RandomUtils.RandomStat(10, 20), RandomUtils.Random(10));//HP

            if (playerName == "mats" || playerName == "andreas")
            {
                player.Health = 1000;
                player.Vision = 100;
                player.Damage = 100;
                player.Armor = 1000;
            }
        }
        void AskForCommand()
        {
            int previusPlayerX = player.X;
            int previusPlayerY = player.Y;
            presenter.Movement();
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            presenter.Clear();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (player.Y != 0)
                        player.Y -= 1;
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (player.X < worldWidth - 1)
                        player.X += 1;
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (player.Y < worldHeight - 1)
                        player.Y += 1;
                    break;

                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (player.X != 0)
                        player.X -= 1;
                    break;

                default:
                    presenter.Incorrect();
                    break;
            }

            if(Room.Rooms[player.X, player.Y].Loot != null && Room.Rooms[player.X, player.Y].Loot is IConsumable)
            {
                presenter.Consume(Room.Rooms[player.X, player.Y].Loot);
                player.Health += Room.Rooms[player.X, player.Y].Loot.Health;
                Room.Rooms[player.X, player.Y].Loot = null;
            }

            if (Room.Rooms[player.X, player.Y].Loot != null && player.Encumbrance +
                Room.Rooms[player.X, player.Y].Loot.Weight <= 40)
            {
                player.Backpack.Add(Room.Rooms[player.X, player.Y].Loot);
                presenter.PickUp(player);
                player.Damage += Room.Rooms[player.X, player.Y].Loot.Damage;
                player.Armor += Room.Rooms[player.X, player.Y].Loot.Armor;
                if (Room.Rooms[player.X, player.Y].Loot.Name == "Torch")
                {
                    player.Vision = 100;
                }
                player.Encumbrance += Room.Rooms[player.X, player.Y].Loot.Weight;
                Room.Rooms[player.X, player.Y].Loot = null;
            }
            Monster roomMonster = Room.Rooms[player.X, player.Y].RoomMonster;

            if (roomMonster != null)
            {
                if (player.Vision > Room.Rooms[player.X, player.Y].Brightness)
                {
                    bool removeMonster = false;
                    do
                    {
                        presenter.Encounter(roomMonster);

                        player.Fight(roomMonster);
                        if (roomMonster.Health <= 0)
                        {
                            removeMonster = true;

                        }
                        else
                            roomMonster.Fight(player);
                        if (roomMonster.Health <= 0)
                        {
                            removeMonster = true;
                        }

                    } while (player.Health > 0 && roomMonster.Health > 0);
                    if (removeMonster)
                    {
                        Room.Rooms[player.X, player.Y].RoomMonster = null;
                        monsterCount--;
                    }
                }
                else
                {
                    presenter.Blind();
                    roomMonster.Fight(player);
                    player.X = previusPlayerX;
                    player.Y = previusPlayerY;
                }
            }
        }
    }
}
