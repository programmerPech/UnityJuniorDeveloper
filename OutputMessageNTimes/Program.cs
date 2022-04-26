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

            for(int i = 0; i < timesCount; i++)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}
