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
            player1.ShowPlayer();
            player2.ShowPlayer();
            player3.ShowPlayer();
            Console.ReadKey();
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public void ShowPlayer()
        {
            Renderer renderer = new Renderer();
            renderer.RenderPlayer(_positionX, _positionY);
        }
    }

    class Renderer
    {
        public void RenderPlayer(int positionX,int positionY)
        {
            if (positionX < 1)
                positionX = 1;

            if (positionY < 1)
                positionY = 1;

            Console.SetCursorPosition(positionY, positionX - 1);
            Console.Write("0");
            Console.SetCursorPosition(positionY - 1, positionX);
            Console.Write("-");
            Console.SetCursorPosition(positionY + 1, positionX);
            Console.Write("-");
            Console.SetCursorPosition(positionY, positionX);
            Console.Write("|");
            Console.SetCursorPosition(positionY - 1, positionX + 1);
            Console.Write("/");
            Console.SetCursorPosition(positionY + 1, positionX + 1);
            Console.Write("\\");
        }
    }
}
