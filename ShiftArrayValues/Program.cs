using System;

namespace ShiftArrayValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementCount = 10;
            int[] oneDimensionalArray = new int[elementCount];
            Random random = new Random();
            int beginRandomRange = 1;
            int endRandomRange = 10;
            int shiftCount = 0;

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < oneDimensionalArray.Length; i++)
            {
                oneDimensionalArray[i] = random.Next(beginRandomRange, endRandomRange);
                Console.Write(oneDimensionalArray[i]+" ");
            }

            Console.WriteLine("\nВведите число, на которое хотите сдвинуть массив влево: ");
            shiftCount =Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < shiftCount; i++)
            {
                int firstElement = oneDimensionalArray[0];

                for (int j = 1; j < elementCount; j++)
                {
                    oneDimensionalArray[j - 1] = oneDimensionalArray[j];
                }

                oneDimensionalArray[elementCount - 1] = firstElement;
            }

            Console.WriteLine("Сдвинутый массив:");

            foreach (int element in oneDimensionalArray)
            {
                Console.Write(element+" ");
            }
        }
    }
}
