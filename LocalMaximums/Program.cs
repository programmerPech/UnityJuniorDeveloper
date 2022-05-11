using System;

namespace LocalMaximums
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = 3;
            int[] oneDimensionalArray = new int[elementsCount];
            Random random = new Random();
            int beginRandomRange = 0;
            int endRandomRange = 10;

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < oneDimensionalArray.Length; i++)
            {
                oneDimensionalArray[i] = random.Next(beginRandomRange, endRandomRange);
                Console.Write(oneDimensionalArray[i] + " ");
            }

            Console.WriteLine("\nЛокальные максимумы: ");

            if (oneDimensionalArray[0] > oneDimensionalArray[1])
            {
                Console.Write(oneDimensionalArray[0] + " ");
            }

            for (int i = 1; i < oneDimensionalArray.Length-1; i++)
            {
                if (oneDimensionalArray[i - 1] < oneDimensionalArray[i] && oneDimensionalArray[i + 1] < oneDimensionalArray[i])
                {
                    Console.Write(oneDimensionalArray[i] + " ");
                }
            }

            if (oneDimensionalArray[oneDimensionalArray.Length - 1] > oneDimensionalArray[oneDimensionalArray.Length - 2])
            {
                Console.Write(oneDimensionalArray[oneDimensionalArray.Length - 1]);
            }
        }
    }
}
