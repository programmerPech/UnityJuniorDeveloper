using System;
using System.Collections.Generic;

namespace ShopQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            double bill = 0;
            int countClients = 10;
            Queue<double> purchaseSum = new Queue<double>(countClients);
            purchaseSum.Enqueue(1000.28);
            purchaseSum.Enqueue(982.12);
            purchaseSum.Enqueue(93.12);
            purchaseSum.Enqueue(560);
            purchaseSum.Enqueue(122.89);
            purchaseSum.Enqueue(1.00);
            purchaseSum.Enqueue(72.09);
            purchaseSum.Enqueue(69.99);
            purchaseSum.Enqueue(1092);
            purchaseSum.Enqueue(500);

            while(purchaseSum.Count>0)
            {
                ServiceClient(purchaseSum, ref bill);
            }

            Console.WriteLine("\b\bМы обслужили всех клиентов. На нашем счету "+bill);
        }

        static void ServiceClient(Queue<double> purchaseSum, ref double bill)
        {
            Console.WriteLine("\b\bОбслуживаем клинта с сумой покупки " + purchaseSum.Peek());
            bill += purchaseSum.Dequeue();
            Console.WriteLine("После обслживания клиента на нашем счету: "+bill);
            Console.WriteLine("Нажмите любую клавишу для обслуживания следующего клиента.");
            Console.ReadKey();
        }
    }
}
