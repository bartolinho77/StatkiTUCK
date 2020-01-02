using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Statki
{
    class Ship
    {
        private int StartCoordX;
        private int StartCoordY;
        private bool[] StateOfFlagpoles;// { get; set; }
        private bool IsVertical;

        public Ship(int NumberOfFlagpoles, int StartPosX, int StartPosY, bool Vertical)
        {
            StartCoordX = StartPosX;
            StartCoordY = StartPosY;

            StateOfFlagpoles = new bool[NumberOfFlagpoles];

            for (int i = 0; i < NumberOfFlagpoles; i++)
            {
                StateOfFlagpoles[i] = true; //is alive
            }

            IsVertical = Vertical;
        }



        public bool HitIt(int HitX, int HitY)
        {
            if (IsVertical && HitX == StartCoordX)
            {
                if (0 <= (HitY - StartCoordY) && (HitY - StartCoordY) < StateOfFlagpoles.Length)
                {
                    StateOfFlagpoles[HitY - StartCoordY] = false;
                    return true;
                }

            }
            else if (!IsVertical && HitY == StartCoordY)
            {
                if (0 <= (HitX - StartCoordX) && (HitX - StartCoordX) < StateOfFlagpoles.Length)
                {
                    StateOfFlagpoles[HitX - StartCoordX] = false;
                    return true;
                }
            }

            return false;
        }




        public bool HasBeenDestroyed()
        {
            for (int i = 0; i < StateOfFlagpoles.Length; i++)
            {
                if (StateOfFlagpoles[i]) return false;
            }
            return true;
        }
    }



    class Board
    {
        private int iSize;
        private int[,] board;
        public Board(int x)
        {
            iSize = x;
            board = new int[iSize,iSize];
            for (int i = 0; i < iSize; i++)
            {
                for(int j = 0; j < iSize; j++)
                { 
                    board[i, j] = 0;
                }
            }
        }
        public void DrawBoard(Ship[] AllShipsInGame)
        {
            for (int i = 0; i < iSize; i++)
            {
                string row = "";
                for (int j = 0; j < iSize; j++)
                {
                    row += board[i, j];
                }
                Console.WriteLine(row);
            }
        }
    }


    class Statistics
    {

    }

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


            Ship[] ships1 = {
                new Ship(3,4,5,false),
                new Ship(3,2,2,true),
                new Ship(1,4,2,true),
                new Ship(5,1,7,false)
            };

            Ship[] ships = new Ship[5];
            
            for (int i = 0; i < ships.Length; i++)
            {
                int f, x, y;
                bool vert;
                ships[i] = new Ship(f, x, y, vert);
            }
            Random lol = new Random();
            lol.Next();
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
                    if (ships[i].HitIt(x, y)) 
                        Console.WriteLine("Have you hit successfully? {0}", ships[i].HitIt(x, y));
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
