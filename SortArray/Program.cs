using System;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] oneDimensionalArray = new int[10];
            Random random = new Random();
            int beginRandomRange = 0;
            int endRandomRange = 10;
            int temporaryElement;

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < oneDimensionalArray.Length; i++)
            {
                oneDimensionalArray[i] = random.Next(beginRandomRange, endRandomRange);
                Console.Write(oneDimensionalArray[i] + " ");
            }

            for (int i = 0; i < oneDimensionalArray.Length-1; i++)
            {
                for (int j = i + 1; j < oneDimensionalArray.Length; j++)
                {
                    if (oneDimensionalArray[i] > oneDimensionalArray[j])
                    {
                        temporaryElement = oneDimensionalArray[i];
                        oneDimensionalArray[i] = oneDimensionalArray[j];
                        oneDimensionalArray[j] = temporaryElement;
                    }
                }
            }

            Console.WriteLine("\nОтсортированный массив: ");

            foreach (int element in oneDimensionalArray)
            {
                Console.Write(element+" ");
            }
        }
    }
}
