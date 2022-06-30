using System;
using System.Collections.Generic;

namespace GladiatorsFights
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = false;

            while (isWork == true)
            {
                Fight fight = new Fight();

                if (fight.TryCreate())
                {
                    Console.ReadKey();
                    Console.Clear();
                    fight.Summary();
                    fight.ShowResult();
                }
            }
        }
    }

    class Fight
    {
        private Gladiator _leftGladiator;
        private Gladiator _rightGladiator;
        private List<Gladiator> _gladiators = new List<Gladiator>();
        
        public Fight()
        {
            _gladiators.Add(new Phantom("Фантом", 80, 50, 20));
            _gladiators.Add(new Knight("Рыцарь", 100, 70, 35));
            _gladiators.Add(new Archer("Лучник", 40, 55, 20));
            _gladiators.Add(new Healer("Целитель", 30, 100, 15));
            _gladiators.Add(new Warrior("Воин", 65, 60, 25));
        } 

        public bool TryCreate()
        {
            Console.WriteLine("Боец 1:");
            ChooseGladiator(out _leftGladiator);
            Console.WriteLine("Боец 2:");
            ChooseGladiator(out _rightGladiator);

            if(_leftGladiator == null || _rightGladiator == null)
            {
                Console.WriteLine("Ошибка при при выборе бойца.");
                return false;
            }
            else
            {
                Console.WriteLine("Бойцы выбраны.");
                return true;
            }
        }

        public void ShowResult()
        {
            if(_leftGladiator.Health<=0 && _rightGladiator.Health <= 0)
            {
                Console.WriteLine("Ничья, оба бойца погибли.");
                Console.WriteLine(_$"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
            else if(_leftGladiator.Health <= 0)
            {
                Console.WriteLine($"{_rightGladiator.Name} одержал победу");
                Console.WriteLine(_$"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
            else if(_rightGladiator.Health <= 0)
            {
                Console.WriteLine($"{_leftGladiator.Name} одержал победу");
                Console.WriteLine(_$"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
        }
        
        public void Summary()
        {

        }
    }

    class Gladiator
    {

    }
}
