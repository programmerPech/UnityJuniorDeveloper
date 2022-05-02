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
            int twoDegree = 1;
            int degree = 0;

            while (randomNumber >= twoDegree)
            {
                twoDegree *= 2;
                degree++;
            }

            Console.WriteLine($"заданное число {randomNumber}, степень {degree}, число в степени 2 {twoDegree}");
        }
    }
}
