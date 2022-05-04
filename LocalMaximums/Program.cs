using System;

namespace LocalMaximums
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementsCount = 30;
            int[] oneDimensionalArray = new int[elementsCount];
            Random random = new Random();
            int beginRandomRange = 0;
            int endRandomRange = 10;

            Console.WriteLine("Исходный массив: ");

            for(int i = 0; i < oneDimensionalArray.Length; i++)
            {
                oneDimensionalArray[i] = random.Next(beginRandomRange, endRandomRange);
                Console.Write(oneDimensionalArray[i] + " ");
            }

            Console.WriteLine("\nЛокальные максимумы: ");

            for(int i = 0; i < oneDimensionalArray.Length; i++)
            {
                if (i == 0)
                {
                    if (oneDimensionalArray[i] > oneDimensionalArray[i + 1])
                    {
                        Console.Write(oneDimensionalArray[i] + " ");
                    }
                }
                else if (i == oneDimensionalArray.Length - 1)
                {
                    if(oneDimensionalArray[i] > oneDimensionalArray[i - 1])
                    {
                        Console.Write(oneDimensionalArray[i]);
                    }
                }
                else
                {
                    if(oneDimensionalArray[i-1]<oneDimensionalArray[i] && oneDimensionalArray[i + 1] < oneDimensionalArray[i])
                    {
                        Console.Write(oneDimensionalArray[i] + " ");
                    }
                }
            }
        }
    }
}
