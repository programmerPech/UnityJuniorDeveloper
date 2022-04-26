using System;

namespace SumOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int beginRandom = 0;
            int endRandom = 100;
            int number = rand.Next(beginRandom, endRandom);
            Console.WriteLine($"Рандомное число number = {number}");
            int sumOfNumbers=0;

            for(int i= 0; i<=number; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sumOfNumbers += i;
            }

            Console.WriteLine("Cумма всех положительных чисел меньше number (включая число), которые кратные 3 или 5 равна "+sumOfNumbers);
        }
    }
}
