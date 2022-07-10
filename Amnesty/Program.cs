using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Все преступники Арстоцки: ");
            CriminalArstotzka criminal = new CriminalArstotzka();
            Console.WriteLine("\nВ стране Арстоцка была проведена амнистия всех антиправительственных заключенных\n\n" +
                "Теперь в тюрьме сидят:");
            criminal.Amnesty();
        }
    }
    
    class CriminalArstotzka
    {
        private List<CriminalPerson> _criminals = new List<CriminalPerson>();

        public CriminalArstotzka()
        {
            _criminals.Add(new CriminalPerson("Сорокин Лев Даниилович","Антиправительственное"));
            _criminals.Add(new CriminalPerson("Демидова Амелия Львовна","В сфере экономики"));
            _criminals.Add(new CriminalPerson("Ильина Алина Романовна", "Антиправительственное"));
            _criminals.Add(new CriminalPerson("Власов Давид Никитич", "Против общественной безопасности"));
            _criminals.Add(new CriminalPerson("Соловьев Марсель Павлович","Против мира"));
            _criminals.Add(new CriminalPerson("Михайлов Даниил Сергеевич", "Антиправительственное"));
            _criminals.Add(new CriminalPerson("Смирнова Ева Алексеевна", "Против мира"));
            _criminals.Add(new CriminalPerson("Рудаков Иван Денисович", "Антиправительственное"));
            _criminals.Add(new CriminalPerson("Кудрявцев Богдан Павлович", "В сфере экономики"));
            _criminals.Add(new CriminalPerson("Покровская Юлия Романовна", "Антиправительственное"));

            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }

        public void Amnesty()
        {
            _criminals = _criminals.Where(criminal => criminal.Crime != "Антиправительственное").ToList();

            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }
        }
    }

    class CriminalPerson
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public CriminalPerson (string name, string crime)
        {
            Name = name;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ФИО: {Name} \t Вид преступления: {Crime}");
        }
    }
}
