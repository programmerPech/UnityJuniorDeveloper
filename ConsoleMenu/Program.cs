using System;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "";
            string userInput = "";
            int beginRandomNumberRange = 0;
            int endRandomNumberRange = 101;

            while (userInput != "Exit")
            {
                Console.WriteLine("Добро пожаловать в консольное меню выберите команду. \nНапишите ClearConsole-чтобы очистить консоль.\nChangeForegroundColor-чтобы изменить цвет текста.");
                Console.WriteLine("RandomNumber-чтобы вывести на экран случайное число от 0 до 100.\nSetName-установить имя.\nWriteName-вывести имя.\nExit-выйти из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "ClearConsole":
                        Console.Clear();
                        Console.WriteLine("Консоль очищена!");
                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.\n");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "ChangeForegroundColor":
                        Console.WriteLine("Выберите цвет:\nВведите 1-чтобы выбрать красный\n2-чтобы выбрать синий\n3-чтобы выбрать зеленый\n4-чтобы выбрать белый\n0-чтобы отменить выбор цвета");
                        string userConsoleColor = Console.ReadLine();

                        switch (userConsoleColor)
                        {
                            case "1":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "3":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "4":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case "0":
                                break;
                            default:
                                Console.WriteLine("Неизвестная команда.");
                                break;
                        }

                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.\n");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "RandomNumber":
                        Random random = new Random();
                        int randomNumber = random.Next(beginRandomNumberRange, endRandomNumberRange);
                        Console.WriteLine($"Ваше случайное число - {randomNumber}");
                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.\n");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "SetName":
                        Console.Write("Введите ваше имя:");
                        userName = Console.ReadLine();
                        Console.WriteLine($"Имя {userName} установлено.");
                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.\n");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "WriteName":

                        if (userName == "")
                            Console.WriteLine("У вас пока нет имени. Используйте команду SetName, чтобы его установить.");
                        else 
                            Console.WriteLine($"Ваше имя - {userName}.");

                        Console.WriteLine("Для выхода в главное меню нажмите любую клавишу.\n");
                        Console.ReadKey();
                        Console.Write("\b\b");
                        break;
                    case "Exit":
                        break;
                    default:
                        Console.WriteLine("Неверная команда");
                        break;
                }
            }
        }
    }
}
