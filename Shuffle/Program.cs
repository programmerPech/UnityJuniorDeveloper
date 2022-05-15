using System;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] oneDimensionalArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Исходный массив: ");
            OutputArray(oneDimensionalArray);
            ShuffleArray(oneDimensionalArray);
            Console.WriteLine("\nПеремешанный массив: ");
            OutputArray(oneDimensionalArray);
        }

        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                SwapElements(array, i, i + random.Next(array.Length - i));
            }
        }

        static void SwapElements(int[] array, int a, int b)
        {
            int temporary = array[a];
            array[a] = array[b];
            array[b] = temporary;
        }
    }
}
