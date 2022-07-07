using System;
using System.Collections.Generic;

namespace CarService
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = 0;
            Console.WriteLine("Добро пожаловать в автосервис!\nВведите количество машин в очереди:");
            bool isNumber -Int32.TryParse(Console.ReadLine(), out inputNumber);

            while (isNumber == false)
            {
                Console.WriteLine("Ошибка! Ожидалось число! Введите количество машин в очереди:");
                isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);
            }

            CarService carService = new CarService(inputNumber);
            carService.Work();
        }
    }

    class CarService
    {
        private double _money;
        private Queue<Car> _cars;
        private Warehouse _details;

        public CarService(int carsCount)
        {
            _money = 5000;
            _details = new Warehouse();
            _cars = new Queue<Car>();
            CreateCars(carsCount);
        }

        public void Work()
        {
            string userInput = "";
            Console.WriteLine("Автосервис открылся и готов к работе.");

            while (userInput != "3" && _cars.Count != 0)
            {
                Console.WriteLine($"В очереди {_cars.Count} машин.\nИнформация о автосервисе:\nБаланс: {_money} у.е.\nВыберите команду:\n1 - Для начала работы.\n2 - Посмотреть детали на складе.\n3 - Для завершения работы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ServiceCar();
                        break;
                    case "2":
                        _details.ShowInfo();
                        Console.ReadKey;
                        Console.Clear();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда. Повторите попытку.");
                }
            }

            Console.WriteLine($"Вы обслужили всех клиентов и ваш баланс составляет {_money}");
            Console.ReadKey();
        }
    }
}
