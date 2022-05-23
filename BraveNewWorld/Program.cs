using System;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int userX = 6;
            int userY = 6;
            int userDX = 0;
            int userDY = 1;
            bool isPlaying = true;
            char[,] map =
            {
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                { '#','#','#','#','#',' ',' ',' ',' ',' ','#','#','#','#','#', },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                { '#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
            };

            Console.CursorVisible = false;
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(userY, userX);
                Console.Write('@');

                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo charKey = Console.ReadKey(true);
                    ChangeDirection(charKey, ref userDX, ref userDY);

                    if (map[userX + userDX, userY + userDY] != '#')
                    {
                        MoveUser(ref userX, ref userY, userDX, userDY);
                    }
                }
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    DX = -1;
                    DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    DX = 1;
                    DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    DX = 0;
                    DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    DX = 0;
                    DY = 1;
                    break;
            }
        }

        static void MoveUser(ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(" ");

            X += DX;
            Y += DY;

            Console.SetCursorPosition(Y, X);
            Console.Write('@');
        }

        static void DrawMap(char [,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                        Console.Write(map[i,j]);
                }

                Console.WriteLine();
            }
        }
    }
}
