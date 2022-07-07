using System;
using System.Collections.Generic;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            string userInput = "";

            while(userInput != "3")
            {
                aquarium.ShowFishes();
                Console.WriteLine("Программа для присмотра за аквариумом.\nВведите порядковый номер команды:\n1 - Добавить рыбу.\n2 - Достать рыбу из аквариума.\n3 - Выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        aquarium.AddFish();
                        break;
                    case "2":
                        aquarium.DeleteFish();
                        break;
                    case "3":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда.");
                        break;
                }

                aquarium.DeleteDeadFish();
                aquarium.IncreaseFishAge();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private int _maxCapacity = 10;
        private List<Fish> _fishes = new List<Fish>();

        public void ShowFishes()
        {
            int numberFish = 1;
            Console.WriteLine("Рыбки в аквариуме:");

            foreach (var fish in _fishes)
            {
                Console.WriteLine($"{numberFish}. {fish.Name} Возраст: {fish.Age} Максимальный возраст: {fish.MaxAge}");
                numberFish++;
            }
        }

        public void AddFish()
        {
            int kindOfFish;
            int age;

            if (_fishes.Count >= _maxCapacity)
            {
                Console.WriteLine($"В аквариуме уже есть {_maxCapacity} рыб. Больше мест нет.") ;
            }
            else
            {
                Console.WriteLine("Выберите разновидность рыбы, которую хотите добавить:");
                Console.WriteLine("1 - Карп\n2 - Лосось\n3 - Осётр\n4 - Щука\n5 - Неизвестная рыба");
                kindOfFish = GetNumber();
                Console.WriteLine("Введите возраст рыбки:");
                age = GetNumber();

                switch (kindOfFish)
                {
                    case 1:
                        _fishes.Add(new Carp(age));
                        break;
                    case 2:
                        _fishes.Add(new Salmon(age));
                        break;
                    case 3:
                        _fishes.Add(new Sturgeon(age));
                        break;
                    case 4:
                        _fishes.Add(new Pike(age));
                        break;
                    case 5:
                        _fishes.Add(new Fish(age));
                        break;
                    default:
                        Console.WriteLine("Такой рыбы у нас нет.");
                        break;
                }
            }
        }

        public void DeleteFish()
        {
            Fish fish;

            if(TryGetFish(out fish))
            {
                _fishes.Remove(fish);
            }
        }

        public void DeleteDeadFish()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].Age >= _fishes[i].MaxAge)
                {
                    _fishes.Remove(_fishes[i]);
                    i--;
                }
            }
        }

        public void IncreaseFishAge()
        {
            foreach (var fish in _fishes)
            {
                fish.Live();
            }
        }

        private bool TryGetFish(out Fish fish)
        {
            int inputNumber;
            Console.WriteLine("Введите порядковый номер рыбы:");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);

            if(isNumber == false)
            {
                Console.WriteLine("Введены некорректные данные! Ожидалось число.");
                fish = null;
                return false;
            }
            else if(inputNumber-1<_fishes.Count && inputNumber > 0)
            {
                fish = _fishes[inputNumber - 1];
                Console.WriteLine("Вы успешно достали рыбу.");
                return true;
            }
            else
            {
                Console.WriteLine("В аквариуме нет рыбы с таким номером.");
                fish = null;
                return false;
            }
        }

        private int GetNumber()
        {
            int number = 0;
            bool isNumber = Int32.TryParse(Console.ReadLine(), out number);

            while(isNumber == false || number < 0 || number > 20)
            {
                Console.WriteLine("Ошибка! Некорректные данные. Повторите попытку:");
                isNumber = Int32.TryParse(Console.ReadLine(), out number);
            }

            return number;
        }
    }

    class Fish
    {
        public string Name { get; protected set; }
        public int Age { get; private set; }
        public int MaxAge { get; protected set; }

        public Fish(int age)
        {
            Random random = new Random();
            int minimumAge = 2;
            int maximumAge = 16;
            Name = "Неизвестная рыба";
            Age = age;
            MaxAge = random.Next(minimumAge, maximumAge);
        }

        public void Live()
        {
            Age++;
        }
    }

    class Carp : Fish
    {
        public Carp(int age) : base(age)
        {
            Name = "Карп";
            MaxAge = 10;
        }
    }

    class Salmon : Fish
    {
        public Salmon(int age) : base(age)
        {
            Name = "Лосось";
            MaxAge = 3;
        }
    }

    class Pike : Fish
    {
        public Pike(int age) : base(age)
        {
            Name = "Щука";
            MaxAge = 6;
        }
    }

    class Sturgeon : Fish
    {
        public Sturgeon(int age) : base(age)
        {
            Name = "Осётр";
            MaxAge = 20;
        }
    }
}
