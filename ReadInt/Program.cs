using System;

namespace ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число:");
            int inputNumber;
            inputNumber = RequestNumber(Console.ReadLine());
            Console.WriteLine("Вы ввели число " + inputNumber);
        }

        static int RequestNumber(string number)
        {
            int parseResult;

            while (int.TryParse(number, out parseResult) != true)
            { 
                Console.WriteLine("Ошибка! Ожидалось целое число.\nВведите число: ");
                number = Console.ReadLine();
            }

            return parseResult;
        }
    }
}
