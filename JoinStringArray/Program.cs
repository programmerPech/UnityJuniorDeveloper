using System;
using System.Collections.Generic;

namespace JoinStringArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers1 = new string[5] { "1", "2", "1", "2", "1" };
            string[] numbers2 = new string[5] { "4", "2", "1", "4", "3" };
            List<string> newNumbers = new List<string>(0);

            Console.WriteLine("Массив строк номер один: ");
            ShowArray(numbers1);
            Console.WriteLine("\nМассив строк номер два: ");
            ShowArray(numbers2);

            JoinArrays(newNumbers, numbers1);
            JoinArrays(newNumbers, numbers2);

            Console.WriteLine("\nНовая коллекция");
            ShowArray(newNumbers);
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

        static void JoinArrays(List<string> newNumbers, string[] numbers)
        {
            if (newNumbers.Count == 0)
            {
                newNumbers.Add(numbers[0]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (ContainElement(newNumbers, numbers[i]) == false)
                {
                    newNumbers.Add(numbers[i]);
                }
            }
        }

        static bool ContainElement(List<string> newNumbers, string number)
        {
            for (int i = 0; i < newNumbers.Count; i++)
            {
                if (number == newNumbers[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
