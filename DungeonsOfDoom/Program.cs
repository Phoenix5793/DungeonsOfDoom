using DungeonsOfDoom.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                IGamePresenter presenter = null;
                Console.WriteLine("Press 1 for Light presenter or 2 for Dark presenter\n");
                //Console.WriteLine("1 or 2 player");

                //ConsoleKeyInfo numbersOfPlayer = Console.ReadKey();

                //switch (numbersOfPlayer.Key)
                //{
                //    case ConsoleKey.D1:
                //    case ConsoleKey.NumPad1:
                //        break;

                //    case ConsoleKey.D2:
                //    case ConsoleKey.NumPad2:
                //        break;

                //}

                do
                {
                    ConsoleKeyInfo presenterChoice = Console.ReadKey();
                    switch (presenterChoice.Key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            StandardDisplay standardDisplay = new StandardDisplay();
                            presenter = standardDisplay;
                            break;

                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            AlternativeDisplay alternativeDisplay = new AlternativeDisplay();
                            presenter = alternativeDisplay;
                            break;

                        default:
                            Console.WriteLine("You have to choose either 1 or 2");
                            break;
                    }
                } while (presenter == null);

                presenter.Clear();
                Game game = new Game(presenter);
                game.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops something went very wrong!", e.Message);
            }
        }
    }
}
