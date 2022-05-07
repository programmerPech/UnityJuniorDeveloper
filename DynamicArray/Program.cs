using System;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int elementCount = 0;
            int[] dynamicArray = new int[elementCount];
            string userInput = "";

            while (userInput != "exit")
            {
                Console.WriteLine("Введите числа, которые хотите добавить в массив\nИли команду sum для суммирования уже имеющихся чисел в массиве\nИли команду exit для выхода из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        int sumElementsArray = 0;

                        for(int i=0; i < dynamicArray.Length; i++)
                        {
                            sumElementsArray += dynamicArray[i];
                        }

                        Console.WriteLine($"Сумма элементов динамического массива равна - {sumElementsArray}");
                        Console.WriteLine("Для продолжения нажмите любую клавишу.");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "exit":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        int[] temporaryDynamicArray = new int[dynamicArray.Length + 1];

                        for (int i = 0; i < dynamicArray.Length; i++)
                        {
                            temporaryDynamicArray[i] = dynamicArray[i];
                        }

                        temporaryDynamicArray[temporaryDynamicArray.Length - 1] = Convert.ToInt32(userInput);
                        dynamicArray = temporaryDynamicArray;
                        Console.WriteLine("В динамический массив добавлено число " + userInput);
                        Console.WriteLine("Для продолжения нажмите любую клавишу.");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                }
            }
        }
    }
}
