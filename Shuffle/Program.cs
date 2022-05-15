using System;

namespace Shuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Исходный массив: ");
            OutputArray(numbers);
            Shuffle(numbers);
            Console.WriteLine("\nПеремешанный массив: ");
            OutputArray(numbers);
        }

        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                SwapElements(array, i, i + random.Next(array.Length - i));
            }
        }

        static void SwapElements(int[] array, int firstIndex, int secondIndex)
        {
            int temporary = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temporary;
        }
    }
}
