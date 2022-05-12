using System;

namespace ReadInt
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestNumber();
        }

        static void RequestNumber()
        {
            string inputNumber = "";
            int parseResult;

            while(int.TryParse(inputNumber, out parseResult) != true)
            {
                Console.WriteLine("Введите число:");
                inputNumber = Console.ReadLine();

                if(int.TryParse(inputNumber, out parseResult) != true)
                    Console.WriteLine("Ошибка! Ожидалось целое число.");
            }

            Console.WriteLine("Вы ввели число "+parseResult);
        }
    }
}
