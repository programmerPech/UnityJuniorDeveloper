using System;
using System.Collections.Generic;

namespace TrainPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Plan plan = new Plan();
            string userInput = "";

            while (userInput != "2")
            {
                Console.WriteLine("Программа для создания плана поездов.\nВыберите команду:\n1 - Составить план\n2 - Выйти из программы.");

                if (plan.GetPlansCount() == 0)
                {
                    Console.WriteLine("Нет текущих планов.");
                }
                else
                {
                    plan.Show();
                }

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        plan.Create();
                        break;
                    case "2":
                        Console.WriteLine("Выход из программы");
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда!");
                        break;
                }
            }
        }
    }

    class Plan
    {
        private List<string> _plans = new List<string>();
        private Train _train = new Train();
        private Queue<Route> _routes = new Queue<Route>();
        private Random _random = new Random();
        private string _startPoint;
        private string _endPoint;

        public void Create()
        {
            if (TryCreateRoute() == true)
            {
                int passengersCount;
                passengersCount = SellTickets();

                if (TryCreateTrain(passengersCount))
                {
                    Console.WriteLine("План поезда успешно создан.");
                    _plans.Add("План " + _startPoint + " - " + _endPoint + " выполняется.");
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Не удалось создать маршрут. Названия городов введены некорректно.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Show()
        {
            foreach (var plan in _plans)
            {
                Console.WriteLine(plan);
            }
        }

        public int GetPlansCount()
        {
            return _plans.Count;
        }
        private int SellTickets()
        {
            Console.WriteLine("Процесс продажи билетов...");
            int passengersCount = GetPassengersCount();
            Console.WriteLine(passengersCount + " человек купили билеты.");
            return passengersCount;
        }

        private int GetPassengersCount()
        {
            int minimumPassengersCount = 50;
            int maximumPassengersCount = 200;
            return _random.Next(minimumPassengersCount, maximumPassengersCount);
        }

        private bool TryCreateTrain(int passengersCount)
        {
            _train.Create();

            if (_train.Capacity >= passengersCount)
            {
                _routes.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка! В поезде недостаточно мест!");
                return false;
            }
        }

        private bool TryCreateRoute()
        {
            Console.WriteLine("Создание направления:\nВведите город отправления: ");
            _startPoint = Console.ReadLine();
            Console.WriteLine("Введите город прибытия: ");
            _endPoint = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(_startPoint) == false && string.IsNullOrWhiteSpace(_endPoint) == false)
            {
                _routes.Enqueue(new Route(_startPoint, _endPoint));
                Console.WriteLine("Направление успешно создано!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Route
    {
        public string StartPoint { get; private set; }
        public string EndPoint { get; private set; }

        public Route(string startPoint, string endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }

    class Train
    {
        public int Capacity { get; private set; }
        public int VansCount { get; private set; }
        private List<Van> _vans = new List<Van>();

        public void Create()
        {
            if (TryCreateVan())
            {
                Console.WriteLine("Поезд успешно создан.");
            }
        }

        private bool TryCreateVan()
        {
            Console.WriteLine("Введите количество вагонов: ");
            int vansCount;

            if (GetNumber(out vansCount))
            {
                VansCount = vansCount;
                Console.WriteLine("Успешно созданы " + VansCount + " вагонов.");

                if (TrySetCapacityVan())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool TrySetCapacityVan()
        {
            Console.WriteLine("Введите вместимость одного вагона: ");
            int seatsCount;

            if (GetNumber(out seatsCount))
            {
                for (int i = 0; i < VansCount; i++)
                {
                    _vans.Add(new Van(seatsCount));
                }

                Capacity = seatsCount * VansCount;
                Console.WriteLine($"Вагоны успешно созданы общей вместимостью {Capacity} мест.");
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GetNumber(out int number)
        {
            bool isNumber = Int32.TryParse(Console.ReadLine(), out number);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Ожидалось число.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class Van
    {
        private int _capacity;

        public Van(int capacity)
        {
            _capacity = capacity;
        }
    }
}
