using System;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Привет, странник! Добро пожаловать в мой магазин кристаллов. Сколько золота у тебя есть? ");
            int goldCount = Convert.ToInt32(Console.ReadLine());
            int crystalPrice = 10;
            int maxCrystalCount = goldCount / crystalPrice;
            Console.Write($"Ты можешь купить {maxCrystalCount} кристаллов. Сколько кристалов желаешь приобрести? ");
            int crystalCount = Convert.ToInt32(Console.ReadLine());
            goldCount -= crystalCount * crystalPrice;
            Console.WriteLine($"После покупки у тебя появилось {crystalCount} кристаллов и осталось {goldCount} золота."); 
            
        }
    }
}
