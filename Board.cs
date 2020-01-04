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
        /*
        public int Size
            {
                get
                {
                    return size;
                }
            }
        */

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

      public void UpdateBoard(int x, int y, bool hit)
        {
            Map[x, y] = (hit) ? 4 : 8;
        }

        /*public void DrawBoard(Ship[] AllShipsInGame)
        {
            for (int i = 0; i < size; i++)
            {
                string row = "";
                for (int j = 0; j < size; j++)
                {
                    row += map[i, j];
                }
                Console.WriteLine(row);
            }
        }*/
    }

}
