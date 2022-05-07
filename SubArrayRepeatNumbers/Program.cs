using System;

namespace SubArrayRepeatNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementCount = 30;
            int[] oneDimensionalArray = new int[elementCount];
            int repeatNumber = oneDimensionalArray[0];
            int repeatCount = 1;
            int maxRepeatCount = 1;
            Random random = new Random();
            int beginRandomRange = 1;
            int endRandomRange = 6;

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < oneDimensionalArray.Length; i++)
            {
                oneDimensionalArray[i] = random.Next(beginRandomRange, endRandomRange);
                Console.Write(oneDimensionalArray[i]+" ");
            }

            for (int i = 1; i < oneDimensionalArray.Length; i++)
            {
                if(oneDimensionalArray[i] == oneDimensionalArray[i - 1])
                {
                    repeatCount++;

                    if (maxRepeatCount <= repeatCount)
                    {
                        repeatNumber = oneDimensionalArray[i];
                        maxRepeatCount = repeatCount;
                    }
                }
                else
                {
                    repeatCount = 1;
                }
            }

            Console.WriteLine("\nПовторяющееся число: "+repeatNumber);
            Console.WriteLine("Число повторений "+maxRepeatCount);
        }
    }
}
