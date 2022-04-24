using System;

namespace Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int picturesInRow = 3;
            int allPictures = 52;

            int fullRowPictures = allPictures / picturesInRow;
            int picturesLeft = allPictures % picturesInRow;
            Console.WriteLine($"Полностью заполненных рядов с картинками - {fullRowPictures}, картинок осталось: {picturesLeft}.");
        }
    }
}
