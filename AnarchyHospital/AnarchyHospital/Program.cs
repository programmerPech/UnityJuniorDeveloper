using System;
using System.Collections.Generic;
using System.Linq;

namespace AnarchyHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            string userInput = "";

            while (userInput != "4")
            {
                Console.WriteLine("В больнице анархия.\nВыберите действие:\n" +
                    "1 - Сортировка больных по ФИО.\n2 - Сортировка больных по возрасту.\n" +
                    "3 - Поиск по заболеванию.\n4 - Выход из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        hospital.SortByName();
                        break;
                    case "2":
                        hospital.SortByAge();
                        break;
                    case "3":
                        hospital.SearchByDisease();
                        break;
                    case "4":
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

    class Hospital
    {
        private List<Pacient> _pacients = new List<Pacient>();

        public Hospital()
        {
            _pacients.Add(new Pacient("Сорокина Ольга Михайловна", 17, "ОРВИ"));
            _pacients.Add(new Pacient("Стариков Гордей Егорович", 54, "Диабет"));
            _pacients.Add(new Pacient("Гаврилов Роман Ильич", 51, "ОРВИ"));
            _pacients.Add(new Pacient("Анисимов Олег Егорович", 34, "Диабет"));
            _pacients.Add(new Pacient("Михайлов Егор Викторович", 12, "ОРВИ"));
            _pacients.Add(new Pacient("Ковалева Яна Ильинишна", 10, "АСТМА"));
            _pacients.Add(new Pacient("Максимов Марк Егорович", 34, "ОРВИ"));
            _pacients.Add(new Pacient("Еремеева Алиса Михайловна", 45, "ОРВИ"));
            _pacients.Add(new Pacient("Вавилова Ксения Львовна", 18, "АСТМА"));
            _pacients.Add(new Pacient("Денисов Алексей Львович", 22, "АСТМА"));
        }

        public void SortByName()
        {
            Console.WriteLine("Сортировка по ФИО:");
            var sortedPacients = _pacients.OrderBy(pacient => pacient.Name).ToList();
            ShowPacients(sortedPacients);
        }

        public void SortByAge()
        {
            Console.WriteLine("Сортировка по возрасту:");
            var sortedPacients = _pacients.OrderBy(pacient => pacient.Age).ToList();
            ShowPacients(sortedPacients);
        }

        public void SearchByDisease()
        {
            Console.WriteLine("Поиск по заболеванию. Введите название заболевания: ");
            string inputDisease = Console.ReadLine();
            var sortedPacients = _pacients.Where(pacient => pacient.Disease.ToLower() == inputDisease.ToLower()).ToList();

            if(sortedPacients.Count == 0)
            {
                Console.WriteLine("Больных с таким заболеванием нет в базе данных.");
            }
            else
            {
                ShowPacients(sortedPacients);
            }
        }


        private void ShowPacients(List<Pacient> pacients)
        {
            foreach (var pacient in pacients)
            {
                pacient.ShowInfo();
            }
        }
    }

    class Pacient
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Pacient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name} \t Возраст: {Age} \t Заболевание:{Disease}");
        }
    }
}
