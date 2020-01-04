using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StatkiTUCK
{
    
    class Program
    {
        static void Main(string[] args)
        {


            //Ship ship = new Ship(3, 4, 5, false); // długość = 3, początek X = 4, początek Y = 5, poziome;

            /*Ship[] ships1 = {
                new Ship(3,4,5,false),
                new Ship(3,2,2,true),
                new Ship(1,4,2,true),
                new Ship(5,1,7,false)
            };*/
            Console.WriteLine("Provide board size: ");
            int BoardSize = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Provide number of ships: ");
            int NumberOfShips = Convert.ToInt32(Console.ReadLine());
            
            Game NewGame = new Game(BoardSize, NumberOfShips);
            
            bool exit;

            do
            {
                exit = NewGame.LetPlayerShoot();
                
            } while (!exit);

            Console.WriteLine("Congratulations! You've won!");
            Console.ReadKey();
        }
    }
}
