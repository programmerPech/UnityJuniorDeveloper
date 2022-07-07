using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.ShowAviaries();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private Random _random = new Random();

        public void ShowAviaries()
        {
            CreateAviary(4);
            string userInput = "";

            while(userInput != "2")
            {
                Console.WriteLine($"Вас приветствует зоопарк! Зоопарк содержит {_aviaries.Count} вольера с различными животными.\nВведите команду:\n1 - Посмотреть вольеры.\n2 - Выйти из зоопарка.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SelectAviary();
                        break;
                    case "2":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Ошибка! Введена неизвестная команда.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateAviary(int aviaryCount)
        {
            for (int i = 0; i < aviaryCount; i++)
            {
                _aviaries.Add(new Aviary(i, _random));
            }
        }

        private void SelectAviary()
        {
            int aviaryNumber;
            Console.WriteLine("Введите номер вольера, на который хотите посмотреть: ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out aviaryNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Ожидалось число.");
            }
            else if(aviaryNumber <=_aviaries.Count && aviaryNumber > 0)
            {
                _aviaries[aviaryNumber - 1].ShowAnimals();
            }
            else
            {
                Console.WriteLine("Вольера с таким номером у нас нет.");
            }
        }
    }

    class Aviary
    {
        private Dictionary<int, Animal> _animals = new Dictionary<int, Animal>();
        private int _animalKind;

        public Aviary(int animalKind, Random random)
        {
            _animalKind = animalKind;
            int minimumAnimalCount = 2;
            int maximumAnimalCount = 20;
            CreateAnimals(random.Next(minimumAnimalCount, maximumAnimalCount),random);
        }

        public void ShowAnimals()
        {
            Console.WriteLine("Животных в вольере - "+_animals.Count);

            foreach (var animal in _animals)
            {
                Console.WriteLine($"{animal.Key+1}. {animal.Value.Name} пол: {animal.Value.Gender} произносит звук {animal.Value.Sound}");
            }
        }

        private void CreateAnimals(int animalsCount, Random random)
        {
            for (int i = 0; i < animalsCount; i++)
            {
                _animals.Add(i, GetAnimal(_animalKind, random));
            }
        }

        private Animal GetAnimal(int animalId, Random random)
        {
            switch (animalId)
            {
                case 0:
                    return new Lion(random);
                case 1:
                    return new Sheep(random);
                case 2:
                    return new Horse(random);
                case 3:
                    return new Chick(random);
                default:
                    return null;
            }
        }
    }

    class Animal
    {
        public string Gender { get; private set; }
        public string Name { get; protected set; }
        public string Sound { get; protected set; }

        public Animal(Random random)
        {
            Gender = GetAnimalGender(random);
        }

        private string GetAnimalGender(Random random)
        {
            int maximumNumberGender = 2;
            int genderNumber = random.Next(maximumNumberGender);

            if(genderNumber == 0)
            {
                return "Самец";
            }
            else
            {
                return "Самка";
            }
        }
    }

    class Lion : Animal
    {
        public Lion(Random random) : base(random)
        {
            Name = "Лев";
            Sound = "рррррр!";
        }
    }

    class Sheep : Animal
    {
        public Sheep(Random random) : base(random)
        {
            Name = "Овца";
            Sound = "Бе!";
        }
    }

    class Horse : Animal
    {
        public Horse(Random random) : base(random)
        {
            Name = "Лошадь";
            Sound = "Иго-го!!!";
        }
    }

    class Chick : Animal
    {
        public Chick(Random random) : base(random)
        {
            Name = "Цыпенок";
            Sound = "Пиу-пиу-пипиу-пиу-пиу-пипиу-пиу-пиу-пипиу-пипиу!";
        }
    }
}
