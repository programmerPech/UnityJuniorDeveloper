using System;

namespace ExitControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput="";
            
            while (userInput != "exit")
            {
                Console.Write("Введите слово:");
                userInput = Console.ReadLine();
            }
        }
    }
}
