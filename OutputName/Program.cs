using System;

namespace OutputName
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname;
            char userSymbol;
            Console.Write("Здравстуйте! Введите ваше имя: ");
            firstname = Console.ReadLine();
            Console.Write("Теперь введите ваш символ, в который следует заключить имя: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            for (int i = 0; i < firstname.Length; i++)
            {
                Console.Write(userSymbol+" ");
            }

            Console.WriteLine("\n"+userSymbol + " "+ firstname+ " " + userSymbol);

            for (int i = 0; i < firstname.Length; i++)
            {
                Console.Write(userSymbol+" ");
            }
        }
    }
}
