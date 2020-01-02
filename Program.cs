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

            //Create Board
            Console.WriteLine("Provide the size of board (integer): ");
            int SizeOfBoard = Convert.ToInt32(Console.ReadLine());

            Board BoardForThisGame = new Board(SizeOfBoard);

            /*
            Console.WriteLine("Siema, podaj wymiar x: ");
            Int32.TryParse(Console.ReadLine(), out int iWymiarPlanszyX);
            Console.WriteLine("Siema, podaj wymiar y: ");
            Int32.TryParse(Console.ReadLine(), out int iWymiarPlanszyY);
            Console.WriteLine(String.Format("To są podane przez Ciebie wymiary {0} oraz {1}", iWymiarPlanszyX, iWymiarPlanszyY));
            Board MainBoard = new Board(iWymiarPlanszyX, iWymiarPlanszyY);
            */

            //Ship ship = new Ship(3, 4, 5, false); // długość = 3, początek X = 4, początek Y = 5, poziome;


            /*Ship[] ships1 = {
                new Ship(3,4,5,false),
                new Ship(3,2,2,true),
                new Ship(1,4,2,true),
                new Ship(5,1,7,false)
            };*/

            Ship[] ships = new Ship[5];
            
            for (int i = 0; i < ships.Length; i++)
            {
                Random Generator = new Random();
                
                int f = Generator.Next(1, 4);
                bool vert = Convert.ToBoolean(Generator.Next(0,1));
                int y = (vert) ? Generator.Next(0, SizeOfBoard - f) : Generator.Next(0, SizeOfBoard);
                int x = (vert) ? Generator.Next(0, SizeOfBoard) : Generator.Next(0, SizeOfBoard - f);

                for (int j = 0; j < i; j++)
                {
                    if (vert)
                    {
                        for (int y_temp = y; y_temp < y + f; y_temp++)
                        {
                            ships[j].CheckOrHitIt(x, y_temp, true);
                        }
                    }
                    else
                    {
                        for (int x_temp = x; x_temp < x + f; x_temp++)
                        {
                            ships[j].CheckOrHitIt(x_temp, y, true);
                        }
                    }
                }
                

                


                ships[i] = new Ship(f, x, y, vert);
            }
            
            bool exit;

            do
            {
                exit = true;
                Console.WriteLine("Provide X guess: ");
                int x = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Provide Y guess: ");
                int y = Convert.ToInt32(Console.ReadLine());


                for (int i = 0; i < ships.Length; i++)
                {
                    if (ships[i].CheckOrHitIt(x, y)) 
                        Console.WriteLine("Have you hit successfully? {0}", ships[i].CheckOrHitIt(x, y));
                    Console.WriteLine("Ship nr {0} DESTROYED?: {1};", i, ships[i].HasBeenDestroyed());

                    //check if all are destroyed and quit if so
                    //initially exit = true and if at least one flag pole is still ok, exit becomes false;
                    if (!ships[i].HasBeenDestroyed()) exit = false;
                }
            } while (!exit);

            Console.WriteLine("Congratulations! You've won!");
            Console.ReadKey();
        }
    }
}
