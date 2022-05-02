using System;

namespace TwoDegree
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginRandom = 1;
            int endRandom = 10000;
            Random random = new Random();
            int randomNumber = random.Next(beginRandom, endRandom);
            Console.WriteLine("Заданное случайное число: " + randomNumber);
            int baseNumber = 2;
            int numberDegree = 1;
            int degree = 0;

            while (randomNumber >= numberDegree)
            {
                numberDegree *= baseNumber;
                degree++;
            }

            Console.WriteLine($"заданное число {randomNumber}, степень {degree}, число {baseNumber} в степени {degree} равняется {numberDegree}");
        }
    }
}
