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
            bool isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);

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

            while (_cars.Count != 0)
            {
                Console.WriteLine($"В очереди {_cars.Count} машин.\nИнформация о автосервисе:\nБаланс: {_money} у.е.\nВыберите команду:\n1 - Для начала работы.\n2 - Посмотреть детали на складе.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ServiceCar();
                        break;
                    case "2":
                        _details.ShowInfo();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда. Повторите попытку.");
                        break;
                }
            }

            Console.WriteLine($"Вы обслужили всех клиентов и ваш баланс составляет {_money} у.е.");
            Console.ReadKey();
        }

        private void CreateCars(int carCount)
        {
            Random random = new Random();

            for (int i = 0; i < carCount; i++)
            {
                _cars.Enqueue(new Car(random));
            }
        }

        private void ShowBreakage(Car car)
        {
            Console.WriteLine($"Поломка у машины {car.BreakageDetail}. Цена за деталь и работу составляет {Math.Round(_details.GetRepairCost(car), 2)}");
        }

        private void ServiceCar()
        {
            var car = _cars.Dequeue();
            string userInput = "";
            ShowBreakage(car);
            Console.WriteLine("Выберите дальнейшее действие:\n1 - Попытаться отремонтировать машину.\n2 - Отказать клиенту.");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RepairCar(car);
                    break;
                case "2":
                    Cancel();
                    break;
                default:
                    Console.WriteLine("Введена неизвестная команда");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void RepairCar(Car car)
        {
            double totalCost = Math.Round(_details.GetRepairCost(car), 2);
            double workCostRatio = 0.2;
            double workCost = Math.Round(_details.GetRepairCost(car) * workCostRatio, 2);

            if (_details.TryRepairCar(car))
            {
                Console.WriteLine($"Вы починили машину клиента и заработали {totalCost} у.е.");
                _money += totalCost;
            }
            else
            {
                Console.WriteLine($"Вы не починили машину клиента и возмещаете ему ущерб в {workCost} у.е.");
                _money -= workCost;
            }
        }

        private void Cancel()
        {
            double penalty = 500;
            Console.WriteLine($"Вы отказываете клиенту и платите за это штраф в {penalty} у.е.");
            _money -= penalty;
        }
    }

    class Warehouse
    {
        private List<Detail> _details = new List<Detail>();
        private List<DetailCount> _detailsInfo = new List<DetailCount>();
        private Random _random = new Random();

        public Warehouse()
        {
            int minimumDetailsCount = 0;
            int maximumDetailsCount = 3;

            _details.Add(new Detail("Стекло", 150.99));
            _details.Add(new Detail("Бампер", 202.3));
            _details.Add(new Detail("Коробка передач", 1799.20));
            _details.Add(new Detail("Тормозные колодки", 670.75));
            _details.Add(new Detail("Бензобак", 360.49));
            _details.Add(new Detail("Фара", 220.79));
            _details.Add(new Detail("Колесо", 500.9));

            for (int i = 0; i < _details.Count; i++)
            {
                int detailsCount = _random.Next(minimumDetailsCount, maximumDetailsCount);
                _detailsInfo.Add(new DetailCount(_details[i], detailsCount));
            }
        }

        public void ShowInfo()
        {
            int counter = 1;
            Console.WriteLine("Сейчас на складе имеется:");

            foreach (var detailInfo in _detailsInfo)
            {
                Console.WriteLine($"{(counter++)}. Название детали: {detailInfo.Detail.Name} Стоимость: {detailInfo.Detail.Cost} Количество: {detailInfo.Count} штук.");
            }
        }

        public double GetRepairCost(Car car)
        {

            double workCostRatio = 1.2;

            foreach (var detailInfo in _detailsInfo)
            {
                if (car.BreakageDetail == detailInfo.Detail.Name)
                {
                    return detailInfo.Detail.Cost * workCostRatio;
                }
            }

            return 0;
        }

        public bool TryRepairCar(Car car)
        {
            int inputNumber;
            ShowInfo();
            Console.WriteLine("Введите номер деталь, которую хотите выбрать: ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Ожидалось число.");
                return false;
            }
            else if (inputNumber > 0 && inputNumber - 1 < _details.Count && car.BreakageDetail == _detailsInfo[inputNumber - 1].Detail.Name && _detailsInfo[inputNumber - 1].Count <= 0)
            {
                Console.WriteLine("Такие детали закончились на складе.");
                return false;
            }
            else if (inputNumber > 0 && inputNumber - 1 < _details.Count && car.BreakageDetail == _detailsInfo[inputNumber - 1].Detail.Name)
            {
                _detailsInfo[inputNumber - 1].UseDetail();
                return true;
            }
            else
            {
                Console.WriteLine("Деталь не подходит.");
                return false;
            }
        }
    }

    class Detail
    {
        public string Name { get; private set; }
        public double Cost { get; private set; }

        public Detail(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }

    class DetailCount
    {
        public Detail Detail { get; private set; }
        public int Count { get; private set; }

        public DetailCount(Detail detail, int count)
        {
            Detail = detail;
            Count = count;
        }

        public void UseDetail()
        {
            Count--;
        }
    }

    class Car
    {
        private string[] _nameOfBreakages = new string[] { "Разбито стекло", "Помят бампер", "Поломка коробки пеердач", "Отказ тормозных колодок", "Течет бензобак", "Разбита фара", "Пробито колесо" };
        private Random _random = new Random();
        public string BreakageDetail { get; private set; }

        public Car(Random random)
        {
            _random = random;
            CreateBreakages();
        }

        private void CreateBreakages()
        {
            List<string> breakageDetails = new List<string>() { "Стекло", "Бампер", "Коробка передач", "Тормозные колодки", "Бензобак", "Фара", "Колесо" };
            int breakageID = _random.Next(_nameOfBreakages.Length);
            BreakageDetail = breakageDetails[breakageID];
        }
    }
}
