using System;


namespace StatkiTUCK
{
    public class Controller
    {
        public static void Draw(Board board)
            {
            string line;
            string linebreak = "  ";
            for (int i = 0; i< board.Size; i++)
            {
                linebreak += " " + "___";
            }
            Console.WriteLine(Environment.NewLine + linebreak + Environment.NewLine);
                for (int y = board.Size - 1; y >= 0; y--)
                {
                line = y.ToString() + "/|";
                    for (int x = 0; x<board.Size; x++)
                    {
                        line += " " + board.Map[x, y] + " |";
                    }
                Console.WriteLine(line);
                Console.WriteLine(linebreak + Environment.NewLine);
            }
            line = " ";
                for (int i = 0; i< board.Size; i++)
                {
                line += "   " + i;
                }
            Console.WriteLine(line + Environment.NewLine);
            }

        public static void GetUserInput(out short x, out short y, int BoardSize)
        {
           
                do
                {
                    Console.WriteLine("Provide X guess: (only short integers within board size)");
                } while (!short.TryParse(Console.ReadLine(), out x) || x >= BoardSize);

                do
                {
                    Console.WriteLine("Provide Y guess: (only short integers within board size)");
                } while (!short.TryParse(Console.ReadLine(), out y) || y >= BoardSize);

                

        }
    }
}
