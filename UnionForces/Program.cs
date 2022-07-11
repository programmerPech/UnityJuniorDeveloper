using System;
using System.Collections.Generic;
using System.Linq;

namespace UnionForces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Forces forces = new Forces();
            forces.UnionSoldiers();
        }
    }
    class Forces
    {
        private List<Soldier> _firstList = new List<Soldier>();
        private List<Soldier> _secondList = new List<Soldier>();

        public Forces()
        {
            _firstList.Add(new Soldier("Быков Серафим", "Рядовой"));
            _firstList.Add(new Soldier("Морозов Владимир", "Сержант"));
            _firstList.Add(new Soldier("Титов Макар", "Рядовой"));
            _firstList.Add(new Soldier("Белов Владимир", "Ефрейтор"));
            _firstList.Add(new Soldier("Королев Ярослав", "Рядовой"));

            _secondList.Add(new Soldier("Иванов Даниил", "Рядовой"));
            _secondList.Add(new Soldier("Горелов Артём", "Рядовой"));
            _secondList.Add(new Soldier("Суханов Даниил", "Сержант"));
            _secondList.Add(new Soldier("Носов Матвей", "Рядовой"));
            _secondList.Add(new Soldier("Егоров Степан", "Рядовой"));

        }

        public void UnionSoldiers()
        {
            Console.WriteLine("Первый отряд:");
            Show(_firstList);
            Console.WriteLine("Второй отряд:");
            Show(_secondList);
            Console.WriteLine("\nОбъединение отрядов...\n");
            MoveSoldiers();
            Console.WriteLine("Первый отряд:");
            Show(_firstList);
            Console.WriteLine("Второй отряд:");
            Show(_secondList);
        }

        private void MoveSoldiers()
        {
            var selectedSoldiers = _firstList.Where(soldier => soldier.Name.StartsWith("Б"));
            _secondList = _secondList.Union(selectedSoldiers).ToList();
            _firstList = _firstList.Except(selectedSoldiers).ToList();
        }

        private void Show(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Rank { get; private set; }

        public Soldier (string name, string rank)
        {
            Name = name;
            Rank = rank;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name} \t Звание: {Rank}");
        }
    }
}
