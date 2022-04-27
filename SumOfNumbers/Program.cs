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
            int numberThree = 3;
            int numberFive = 5;

            for(int i= 0; i<=number; i++)
            {
                if (i % numberThree == 0 || i % numberFive == 0)
                    sumOfNumbers += i;
            }

            Console.WriteLine("Cумма всех положительных чисел меньше number (включая число), которые кратные 3 или 5 равна "+sumOfNumbers);
        }
    }
}
