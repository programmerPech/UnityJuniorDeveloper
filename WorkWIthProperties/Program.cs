using System;

namespace WorkWIthProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(10, 0);
            Player player2 = new Player(0, 10);
            Player player3 = new Player(10, 10);
            Renderer renderer = new Renderer();
            renderer.RenderPlayer(player1);
            renderer.RenderPlayer(player2);
            renderer.RenderPlayer(player3);
            Console.ReadKey();
        }
    }

    class Player
    {
        public int coordinateX;
        public int coordinateY;

        public Player(int x, int y)
        {
            coordinateX = x;
            coordinateY = y;
        }
    }

    class Renderer
    {
        public void RenderPlayer(Player player)
        {
            if (player.coordinateX < 1)
                player.coordinateX = 1;

            if (player.coordinateY < 1)
                player.coordinateY = 1;

            Console.SetCursorPosition(player.coordinateY, player.coordinateX - 1);
            Console.Write("0");
            Console.SetCursorPosition(player.coordinateY - 1, player.coordinateX);
            Console.Write("-");
            Console.SetCursorPosition(player.coordinateY + 1, player.coordinateX);
            Console.Write("-");
            Console.SetCursorPosition(player.coordinateY, player.coordinateX);
            Console.Write("|");
            Console.SetCursorPosition(player.coordinateY - 1, player.coordinateX + 1);
            Console.Write("/");
            Console.SetCursorPosition(player.coordinateY + 1, player.coordinateX + 1);
            Console.Write("\\");
        }
    }
}
