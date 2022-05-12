using System;

namespace ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            string inputNumber = Console.ReadLine();
            inputNumber = RequestNumber(inputNumber).ToString();
            Console.WriteLine("Вы ввели число " + inputNumber);
        }

        static int RequestNumber(string number)
        {
            int parseResult;

            while (int.TryParse(number, out parseResult) != true)
            {
                if (int.TryParse(number, out parseResult) != true)
                {
                    Console.WriteLine("Ошибка! Ожидалось целое число.\nВведите число: ");
                    number = Console.ReadLine();
                }   
            }

            return parseResult;
        }
    }
}
