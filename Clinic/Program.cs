using System;

namespace Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Добро пожаловать в поликлинику. Вставайте в очередь! Сколько бабушек перед вами в очереди? ");
            int grannyCount = Convert.ToInt32(Console.ReadLine());
            int receptionTime = 10;
            int waitingTime = grannyCount * receptionTime;
            int waitingHours = waitingTime / 60;
            int waitingMinutes = waitingTime % 60;
            Console.WriteLine($"Перед вами в очереди {grannyCount} бабушек, время ожидания составляет {waitingHours} часа(ов) и {waitingMinutes} минут.");
        }
    }
}
