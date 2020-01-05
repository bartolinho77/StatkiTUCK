using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiTUCK
{
    class Game
    {

        private Ship[] ships;
        public Board Board{ get; }
        public Statistics Stats { get; }

        public Game(int boardSize, int numberOfShips)
            {
                Board = new Board(boardSize);
                Stats = new Statistics();
                PrepareBoard(numberOfShips);
            }
        
        public bool LetPlayerShoot(short x, short y)
        {
            bool exit = true;

            
            for (int i = 0; i < ships.Length; i++)
            {
                bool hit = ships[i].CheckOrHitIt(x, y);
                bool destroyed = ships[i].HasBeenDestroyed();
                if (hit)
                {
                    Console.WriteLine("Have you hit successfully? {0}", hit);
                    Board.UpdateBoard(x, y, true);
                    Stats.AddEntry(x, y, true);
                }
                    
                Console.WriteLine("Ship nr {0} DESTROYED?: {1};", i, destroyed);

                //check if all are destroyed and quit if so
                //initially exit = true and if at least one flag pole is still ok, exit becomes false;
                if (!destroyed) exit = false;
            }
            if (Board.Map[x, y] == 0)
            {
                Board.UpdateBoard(x, y, false);
                Stats.AddEntry(x, y, false);
            }
            return exit;
        }
        
        private void PrepareBoard(int numberOfShips)
        {
            ships = new Ship[numberOfShips];


            for (int i = 0; i < ships.Length; i++)
            {
                Random Generator = new Random();
                int f, x, y;
                bool vert;
                bool ship_exists;
                do
                {
                    ship_exists = false;
                    f = Generator.Next(1, 5);
                    vert = Convert.ToBoolean(Generator.Next(2));
                    y = (vert) ? Generator.Next(0, Board.Size - f) : Generator.Next(0, Board.Size);
                    x = (vert) ? Generator.Next(0, Board.Size) : Generator.Next(0, Board.Size - f);
                    for (int j = 0; j < i; j++)
                    {
                        if (vert)
                        {
                            for (int y_temp = y; y_temp < y + f; y_temp++)
                            {
                                if (ships[j].CheckOrHitIt(x, y_temp, true))
                                {
                                    ship_exists = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int x_temp = x; x_temp < x + f; x_temp++)
                            {
                                if (ships[j].CheckOrHitIt(x_temp, y, true))
                                {
                                    ship_exists = true;
                                    break;
                                }

                            }
                        }
                        if (ship_exists)
                            break;
                    }
                } while (ship_exists);

                ships[i] = new Ship(f, x, y, vert);
            }
        }

    }
}
