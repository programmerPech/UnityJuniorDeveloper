using System;

namespace PasswordApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string secretMessage = "ТЫ ЛАПОЧКА!!!";
            string secretPassword = "noProblem";
            string userInputPassword;
            int tryCountLeft=3;
            int tryCount = 3;
            Console.Write("Здравствуйте! Для доступа к тайному сообщению введите пароль: ");

            for (int i= 0; i < tryCount; i++)
            {
                userInputPassword = Console.ReadLine();

                if (userInputPassword == secretPassword)
                {
                    Console.WriteLine("Тайное сообщение: " + secretMessage);
                    break;
                }
                else if (tryCountLeft - i > 0)
                {
                    tryCountLeft--;
                    Console.Write("У вас осталось " + tryCountLeft + " попыток.\n Введите пароль заново: ");
                }
                else Console.WriteLine("У вас закончились попытки. Доступ к тайному сообщению закрыт.");
            }
        }
    }
}
