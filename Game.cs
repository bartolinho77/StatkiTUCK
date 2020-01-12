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
            ships = Board.PrepareBoard(numberOfShips);
        }
        public bool IsGameRunning()
        {
            for (int i=0; i<ships.Length; i++)
            {
                //if at least one ship is still alive, then game is still running
                if(!ships[i].HasBeenDestroyed())
                {
                    return true;
                }
            }
            return false;
        }
        public void LetPlayerShoot(short x, short y)
        {
            for (int i = 0; i < ships.Length; i++)
            {
                bool hit = ships[i].CheckOrHitIt(x, y);
                if (hit)
                {
                    Console.WriteLine("Have you hit successfully? {0}", hit);
                    Board.UpdateBoard(x, y, true);
                    Stats.AddEntry(x, y, true);
                }
            }
            if (Board.Map[x, y] == 0)
            {
                Board.UpdateBoard(x, y, false);
                Stats.AddEntry(x, y, false);
            }
        }
        
        

    }
}
