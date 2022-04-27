using System;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int beginRandom = 0;
            int endRandom = 100;
            int number = random.Next(beginRandom, endRandom);
            Console.WriteLine($"Рандомное число number = {number}");
            int sumOfNumbers=0;
            int multipleNumber1 = 3;
            int multipleNumber2 = 5;

            for(int i= 0; i<=number; i++)
            {
                if (i % multipleNumber1 == 0 || i % multipleNumber2 == 0)
                    sumOfNumbers += i;
            }

            Console.WriteLine($"Cумма всех положительных чисел меньше number (включая число), которые кратные {multipleNumber1} или {multipleNumber2} равна {sumOfNumbers}");
        }
    }
}
