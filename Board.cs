using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiTUCK
{
    class Board
    {
        private int iSize;
        private int[,] board;
        public Board(int x)
        {
            iSize = x;
            board = new int[iSize, iSize];
            for (int i = 0; i < iSize; i++)
            {
                for (int j = 0; j < iSize; j++)
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

}
