using System;

namespace OutputMessageNTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage;
            int timesCount;
            Console.Write("Введите ваше сообщение: ");
            userMessage = Console.ReadLine();
            Console.Write("Введите количество повторов вашего сообщения: ");
            timesCount = Convert.ToInt32(Console.ReadLine());

            while (timesCount-- > 0)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}
