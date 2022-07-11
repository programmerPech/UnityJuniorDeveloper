using System;
using System.Collections.Generic;
using System.Linq;

namespace DetectionOverdue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            Overdue overdue = new Overdue();

            while (userInput != "3")
            {
                Console.WriteLine("Программа для определения просрочки.\nВыберите команду:\n1 - Показать весь набор тушенки.\n" +
                    "2 - Показать просроченные наборы тушенки.\n3 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        overdue.ShowAllProducts();
                        break;
                    case "2":
                        overdue.Detect();
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

    class Overdue
    {
        private List<Stew> _stews = new List<Stew>();
        private int _currentYear;

        public Overdue()
        {
            _currentYear = 2022;
            _stews.Add(new Stew("Тушенка Каждый День", 2018, 5));
            _stews.Add(new Stew("Елинская Тушенка", 2020, 10));
            _stews.Add(new Stew("Говядина тушеная РУЗКОМ", 2010, 5));
            _stews.Add(new Stew("Главпродукт Говядина высший сорт", 2021, 6));
            _stews.Add(new Stew("Тушенка говяжья, сельская кусковая Орелпродукт", 2014, 4));
            _stews.Add(new Stew("Гастроном №1 говядина тушеная", 2016, 5));
            _stews.Add(new Stew("Говядина тушеная РУЗКОМ", 2012, 5));
            _stews.Add(new Stew("Тушенка говяжья, сельская кусковая Орелпродукт", 2020, 4));
            _stews.Add(new Stew("Гастроном №1 говядина тушеная", 2018, 5));
            _stews.Add(new Stew("Елинская Тушенка", 2015, 10));
        }

        public void Detect()
        {
            var overdueStews = _stews.Where(stew => (stew.Year + stew.ShelfLife) <= _currentYear).ToList();
            Show(overdueStews);
        }

        public void ShowAllProducts()
        {
            Show(_stews);
        }

        private void Show(List<Stew> stews)
        {
            int counter = 1;

            foreach (var stew in stews)
            {
                Console.Write((counter++) + ". ");
                stew.ShowInfo();
            }
        }
    }

    class Stew
    {
        private string _name;
        public int Year { get; private set; }
        public int ShelfLife { get; private set; }

        public Stew(string name, int year, int shelfLife)
        {
            _name = name;
            Year = year;
            ShelfLife = shelfLife;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название: {_name} Год выпуска: {Year} Срок годности: {ShelfLife}");
        }
    }
}
