using System;
using System.Collections.Generic;

namespace JoinStringArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers1 = new string[5] { "1", "2", "1", "2", "5" };
            string[] numbers2 = new string[5] { "4", "2", "1", "4", "3" };
            List<string> uniqueNumbers = new List<string>(0);

            Console.WriteLine("Массив строк номер один: ");
            ShowArray(numbers1);
            Console.WriteLine("\nМассив строк номер два: ");
            ShowArray(numbers2);

            JoinArrays(uniqueNumbers, numbers1);
            JoinArrays(uniqueNumbers, numbers2);

            Console.WriteLine("\nНовая коллекция");
            ShowArray(uniqueNumbers);
        }

        static void ShowArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void ShowArray(List<string> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        static void JoinArrays(List<string> uniqueNumbers, string[] numbers)
        {
            if (uniqueNumbers.Count == 0)
            {
                uniqueNumbers.Add(numbers[0]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (ContainElement(uniqueNumbers, numbers[i]) == false)
                {
                    uniqueNumbers.Add(numbers[i]);
                }
            }
        }

        static bool ContainElement(List<string> uniqueNumbers, string number)
        {
            for (int i = 0; i < uniqueNumbers.Count; i++)
            {
                if (number == uniqueNumbers[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
