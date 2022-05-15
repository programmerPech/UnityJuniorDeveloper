using System;

namespace BraveNewWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawMap();
        }

        static void DrawMap()
        {
            Console.CursorVisible = false;

            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#','#','#','#','#',' ',' ',' ',' ',' ','#','#','#','#','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#', },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', }
            };

            int userX = 6;
            int userY = 6;

            while (true)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i,j]);
                    }

                    Console.WriteLine();
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                ConsoleKeyInfo charKey = Console.ReadKey();

                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (map[userX - 1, userY] != '#')
                        {
                            userX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (map[userX + 1, userY] != '#')
                        {
                            userX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        if (map[userX, userY-1] != '#')
                        {
                            userY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        if (map[userX, userY+1] != '#')
                        {
                            userY++;
                        }
                        break;
                }
                Console.Clear();
            }

            static void MoveUser()
            {

            }
        }
    }
}
