using System;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int userPositionX = 6;
            int userPositionY = 6;
            int userDirectionX = 0;
            int userDirectionY = 1;
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
                Console.SetCursorPosition(userPositionY, userPositionX);
                Console.Write('@');

                if (Console.KeyAvailable == true)
                {
                    ConsoleKeyInfo charKey = Console.ReadKey(true);
                    ChangeDirection(charKey, ref userDirectionX, ref userDirectionY);

                    if (map[userPositionX + userDirectionX, userPositionY + userDirectionY] != '#')
                    {
                        MoveUser(ref userPositionX, ref userPositionY, userDirectionX, userDirectionY);
                    }
                }
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }

        static void MoveUser(ref int positionX, ref int positionY, int directionX, int directionY)
        {
            Console.SetCursorPosition(positionY, positionX);
            Console.Write(" ");

            positionX += directionX;
            positionY += directionY;

            Console.SetCursorPosition(positionY, positionX);
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
