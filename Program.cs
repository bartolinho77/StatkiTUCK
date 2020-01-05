using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StatkiTUCK
{
    
    class Program
    {
        static void Main()
        {
            //Ship ship = new Ship(3, 4, 5, false); // długość = 3, początek X = 4, początek Y = 5, poziome;

            /*Ship[] ships1 = {
                new Ship(3,4,5,false),
                new Ship(3,2,2,true),
                new Ship(1,4,2,true),
                new Ship(5,1,7,false)
            };*/

            Console.WriteLine("Welcome to Statki Game. You can choose what size your gameboard will be and decide how many ships will be placed onto it. \n" +
                "In this version there's incorporated a simple Console UI. \n" +
                "0 represents a not inspected field. \n" +
                "1 represents a successful hit. \n" +
                "7 represents a miss.");

            Console.WriteLine("Provide board size: (at least 4)");
            int BoardSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Provide number of ships: (be reasonable)");
            int NumberOfShips = Convert.ToInt32(Console.ReadLine());

            Game NewGame = new Game(BoardSize, NumberOfShips);
            bool exit;

            do
            {
                short x, y;
                bool duplicate;

                Controller.Draw(NewGame.Board);

                do
                {
                    Controller.GetUserInput(out x, out y, BoardSize);
                    duplicate = NewGame.Stats.AlreadyExists(x, y);
                    if (duplicate)
                        Console.WriteLine("You've already guessed this pair!");
                } while (duplicate);

                exit = NewGame.LetPlayerShoot(x, y);

            } while (!exit);

            Console.WriteLine("Congratulations! You've won!");
            Console.WriteLine("You needed {0} movements to sink all the ships! Well done.", NewGame.Stats.History.Rows.Count);
            Console.ReadKey();
        }
    }
}
