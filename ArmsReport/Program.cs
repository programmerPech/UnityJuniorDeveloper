using System;
using System.Collections.Generic;
using System.Linq;

namespace ArmsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();
            report.Show();
        }
    }
    class Report
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Report()
        {
            _soldiers.Add(new Soldier("Семенов Максим","Штык-нож","Рядовой",6));
            _soldiers.Add(new Soldier("Зайцев Никита","Автомат","Сержант", 10));
            _soldiers.Add(new Soldier("Малышев Дмитрий","Пистолет","Ефрейтор",9));
            _soldiers.Add(new Soldier("Кузнецов Даниил","Пулемет","Сержант",11));
            _soldiers.Add(new Soldier("Горшков Иван","Пистолет","Рядовой",9));
        }

        public void Show()
        {
            var armsReport = from Soldier soldier in _soldiers
                                select new
                                {
                                    name = soldier.Name,
                                    rank = soldier.Rank
                                };

            foreach (var soldier in armsReport)
            {
                Console.WriteLine($"Имя: {soldier.name} \t Звание: {soldier.rank}");
            }
        }
    }

    class Soldier
    {
        private string _armament;
        private int _lifeTime;
        public string Name { get; private set; }
        public string Rank { get; private set; }

        public Soldier(string name, string armament, string rank, int lifeTime)
        {
            _armament = armament;
            _lifeTime = lifeTime;
            Name = name;
            Rank = rank;
        }
    }
}
