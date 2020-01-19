using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiTUCK
{
    class Board
    {
        public int Size { get; }
        public int[,] Map { get; }
        
        public Board(int x)
        {
            Size = x;
            Map = new int[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Map[i, j] = 0;
                }
            }
        }

        public Ship[] PrepareBoard(int numberOfShips)
        {
            Ship[] ships = new Ship[numberOfShips];


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
                    y = (vert) ? Generator.Next(0, Size - f) : Generator.Next(0, Size);
                    x = (vert) ? Generator.Next(0, Size) : Generator.Next(0, Size - f);
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
            return ships;
        }

        public void UpdateBoard(int x, int y, bool hit)
        {
            Map[x, y] = (hit) ? 1 : 7;
        }

    }

}
