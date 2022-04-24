using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы пришли в магазин. Сколько золота у вас в кармане?");
            int goldCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Привет, странник! Добро пожаловать в мой магазин.");
        }
    }
}
