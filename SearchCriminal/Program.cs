using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchCriminal
{
    class Program
    {
        static void Main(string[] args)
        {
            CriminalDatabase database = new CriminalDatabase();
            string userInput = "";

            while (userInput != "3")
            {
                Console.WriteLine("База данных с информацией о преступниках.\nВыберите команду:\n1 - Поиск преступника.\n2 - Посмотреть все записи в базе.\n3 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        database.Search();
                        break;
                    case "2":
                        database.Show();
                        break;
                    case "3":
                        Console.WriteLine("Выход из программы.");
                        break;
                    default:
                        Console.WriteLine("Введена неизвестная команда.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }

        }
    }

    class CriminalDatabase
    {
        private List<CriminalPerson> _criminals = new List<CriminalPerson>();

        public CriminalDatabase()
        {
            _criminals.Add(new CriminalPerson("Валерий Альбертович", true, 189, 78, "русский"));
            _criminals.Add(new CriminalPerson("Заточка Аркадий Львович", false, 165, 63, "казах"));
            _criminals.Add(new CriminalPerson("Шпаневский Владимир Артемович", false, 190, 88, "беларус"));
            _criminals.Add(new CriminalPerson("Ростовский Игорь Владиславович", true, 178, 66, "русский"));
            _criminals.Add(new CriminalPerson("Дмитриев Роман Валерьвич", false, 167, 71, "русский"));
            _criminals.Add(new CriminalPerson("Шматко Альберт Антонович", false, 197, 102, "беларус"));
            _criminals.Add(new CriminalPerson("Невский Никита Валерьвич", false, 150, 50, "русский"));
            _criminals.Add(new CriminalPerson("Жнец Алексей Егорович", false, 175, 90, "казах"));
        }
        public void Show()
        {
            int counter = 1;
            Console.WriteLine("Все записи о преступниках в базе данных: ");

            foreach (var criminal in _criminals)
            {
                Console.Write($"{counter++}. ");
                criminal.ShowInfo();
            }
        }

        public void Search()
        {
            int inputHeight;
            int inputWeight;
            string inputNationality;
            Console.Write("Поиск по базе данных преступников: \nВведите рост преступника: ");
            bool isNumber1 = Int32.TryParse(Console.ReadLine(), out inputHeight);
            Console.Write("Введите вес преступника: ");
            bool isNumber2 = Int32.TryParse(Console.ReadLine(), out inputWeight);
            Console.Write("Введите национальность преступника: ");
            inputNationality = Console.ReadLine();

            if(isNumber1 == false || isNumber2 == false)
            {
                Console.WriteLine("Ошибка! Ожидалось число.");
            }
            else if(inputHeight<80 || inputWeight < 20 || inputNationality == null)
            {
                Console.WriteLine("Введены некорректные данные.");
            }
            else
            {
                var filteredCriminals = from criminals in _criminals
                                        where criminals.Height <= inputHeight
                                        && criminals.Weight <= inputWeight
                                        && criminals.Nationality.ToLower() == inputNationality.ToLower()
                                        && criminals.IsArrested == false
                                        select criminals;

                Console.WriteLine("Результаты поиска: ");

                if(filteredCriminals.ToList().Count == 0)
                {
                    Console.WriteLine("Ничего не нашлось в базе.");
                }
                else
                {
                    foreach (var criminal in filteredCriminals)
                    {
                        criminal.ShowInfo();
                    }
                }
            }
        }
    }

    class CriminalPerson
    {
        public string Name { get; private set; }
        public bool IsArrested { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }

        public CriminalPerson(string name, bool isArrested, int height, int weight, string nationality)
        {
            Name = name;
            IsArrested = isArrested;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public void ShowInfo()
        {
            if(IsArrested == true)
                Console.WriteLine($"{Name}. В тюрьме: Да. Рост: {Height}. Вес: {Weight}. Национальность: {Nationality}");
            else
                Console.WriteLine($"{Name}. В тюрьме: Нет. Рост: {Height}. Вес: {Weight}. Национальность: {Nationality}");
        }
    }
}
