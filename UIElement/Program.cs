using System;

namespace UIElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxHealth = 10;
            Console.WriteLine("Программа отрисовки полоски здоровья.");
            Console.WriteLine($"Введите сколько процентов здоровья у вас осталось. Процент должен быть кратным {maxHealth}");
            int health = Convert.ToInt32(Console.ReadLine()) / maxHealth;
            DrawBar(health, maxHealth);
        }

        static void DrawBar(int value, int maxValue)
        {
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar+="#";
            }

            Console.SetCursorPosition(0, 3);
            Console.Write("[");
            Console.Write(bar);
            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar = "_";
            }

            Console.Write(bar + "]");
        }
    }
}
