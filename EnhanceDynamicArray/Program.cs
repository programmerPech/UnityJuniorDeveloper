using System;
using System.Collections.Generic;

namespace EnhanceDynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> dynamicArray = new List<int>(0);
            string userInput = "";

            while (userInput != "exit")
            {
                Console.WriteLine("Введите числа, которые хотите добавить в массив\nИли команду sum для суммирования уже имеющихся чисел в массиве\nИли команду exit для выхода из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        SumElements(dynamicArray);
                        break;
                    case "exit":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        GetNumber(dynamicArray, userInput);
                        break;
                }
            }
        }

        static void SumElements(List<int> dynamicArray)
        {
            int sumElementsArray = 0;

            for (int i = 0; i < dynamicArray.Count; i++)
            {
                sumElementsArray += dynamicArray[i];
            }

            Console.WriteLine($"Сумма элементов динамического массива равна - {sumElementsArray}");
            EndAction();
        }

        static void EndAction()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу.\n");
            Console.ReadKey();
            Console.Write("\b\b");
        }

        static void GetNumber(List<int> dynamicArray, string userInput)
        {
            int number;

            if (Int32.TryParse(userInput, out number))
            {
                dynamicArray.Add(Convert.ToInt32(userInput));
                Console.WriteLine("В динамический массив добавлено число " + userInput);
            }
            else
            {
                Console.WriteLine("Введено не число.");
            }

            EndAction();
        }
    }
}
