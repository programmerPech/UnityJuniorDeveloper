using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Добро пожаловать в конвертер валют. Сколько у вас рублей?");
            float rubBalance = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько у вас долларов?");
            float usdBalance = Convert.ToSingle(Console.ReadLine());
            Console.Write("Сколько у вас юаней?");
            float cnyBalance = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
            float rubToUsd = 0.013f; 
            float usdToRub = 74.75f;
            float rubToCny = 0.088f;
            float cnyToRub = 11.4f; 
            float usdToCny = 6.56f;
            float cnyToUsd = 0.15f;
            int currencyCount;
            string userInput = "";

            while (userInput != "0")
            {
                Console.WriteLine("Напишите 1 - для обмена рублей на доллары");
                Console.WriteLine("2 - для обмена долларов на рубли");
                Console.WriteLine("3 - для обмена рублей на юани");
                Console.WriteLine("4 - для обмена юаней на рубли");
                Console.WriteLine("5 - для обмена долларов на юани");
                Console.WriteLine("6 - для обмена юаней на доллары");
                Console.WriteLine("0 - для выхода из программы");
                Console.Write("Введите команду:");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Сколько рублей хотите обменять на доллары?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        rubBalance -= currencyCount;
                        usdBalance += currencyCount * rubToUsd;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "2":
                        Console.WriteLine("Сколько долларов хотите обменять на рубли?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        usdBalance -= currencyCount;
                        rubBalance += currencyCount * usdToRub;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "3":
                        Console.WriteLine("Сколько рублей хотите обменять на юани?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        rubBalance -= currencyCount;
                        cnyBalance += currencyCount * rubToCny;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "4":
                        Console.WriteLine("Сколько юаней хотите обменять на рубли?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        cnyBalance -= currencyCount;
                        rubBalance += currencyCount * cnyToRub;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "5":
                        Console.WriteLine("Сколько долларов хотите обменять на юани?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        usdBalance -= currencyCount;
                        cnyBalance += currencyCount * usdToCny;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "6":
                        Console.WriteLine("Сколько юаней хотите обменять на доллары?");
                        currencyCount = Convert.ToInt32(Console.ReadLine());
                        cnyBalance -= currencyCount;
                        usdBalance += currencyCount * cnyToUsd;
                        Console.WriteLine($"Ваш баланс: {rubBalance} рублей, {usdBalance} долларов и {cnyBalance} юаней.");
                        break;
                    case "0":
                        break;
                    default: 
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            }
        }
    }
}
