using System;
using System.Collections.Generic;

namespace GladiatorsFights
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

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
                else
                {
                    Console.ReadKey();
                    Console.Clear();
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

            if(_leftGladiator == null)
            {
                Console.WriteLine("Ошибка при при выборе бойца.");
                return false;
            }

            Console.WriteLine("Боец 2:");
            ChooseGladiator(out _rightGladiator);

            if (_rightGladiator == null)
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
            if (_leftGladiator.Health <= 0 && _rightGladiator.Health <= 0)
            {
                Console.WriteLine("Ничья, оба бойца погибли.");
                Console.WriteLine($"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
            else if (_leftGladiator.Health <= 0)
            {
                Console.WriteLine($"{_rightGladiator.Name} одержал победу");
                Console.WriteLine($"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
            else if (_rightGladiator.Health <= 0)
            {
                Console.WriteLine($"{_leftGladiator.Name} одержал победу");
                Console.WriteLine($"{_leftGladiator.Name} - {_leftGladiator.Health}\n{_rightGladiator.Name} - {_rightGladiator.Health}");
            }
        }

        public void Summary()
        {
            while (_leftGladiator.Health > 0 && _rightGladiator.Health > 0)
            {
                _leftGladiator.UseSpecialAbility();
                _rightGladiator.UseSpecialAbility();
                _leftGladiator.ShowStats();
                _rightGladiator.ShowStats();
                _leftGladiator.TakeDamage(_rightGladiator.Damage);
                _rightGladiator.TakeDamage(_leftGladiator.Damage);
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ChooseGladiator(out Gladiator gladiator)
        {
            ShowGladiators();
            int inputNumber = -1;
            Console.WriteLine("Введите идентификатор бойца: ");
            bool isNumber = Int32.TryParse(Console.ReadLine(), out inputNumber);

            if (isNumber == false)
            {
                Console.WriteLine("Ошибка! Ожидалось числовое значение.");
                gladiator = null;
            }
            else if (inputNumber > 0 && inputNumber - 1 < _gladiators.Count)
            {
                gladiator = _gladiators[inputNumber - 1];
                _gladiators.Remove(gladiator);
                Console.WriteLine($"Боец {gladiator.Name} успешно выбран.");
            }
            else
            {
                Console.WriteLine("Не удалось найти бойца с таким идентификатором.");
                gladiator = null;
            }
        }

        private void ShowGladiators()
        {
            Console.WriteLine("Список доступных бойцов: ");

            for (int i = 0; i < _gladiators.Count; i++)
            {
                Console.Write(i + 1 + ".");
                _gladiators[i].ShowStats();
            }
        }
    }

    class Gladiator
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public Gladiator(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }

        public void TakeDamage(int damageGladiator)
        {
            int totalDamage = 0;
            int blockedDamageArmor = 100;

            totalDamage = damageGladiator * (blockedDamageArmor - Armor) / blockedDamageArmor;
            Health -= totalDamage;

            Console.WriteLine($"{Name} получил {totalDamage} урона.");
        }

        public void ShowStats()
        {
            Console.WriteLine($"{Name}. Здоровье: {Health}. Урон: {Damage}. Броня: {Armor}");
        }

        public void UseSpecialAbility()
        {
            Random random = new Random();
            int maximumPercents = 100;
            int chanceUsingAbility = random.Next(maximumPercents);
            UseSkill(chanceUsingAbility);
        }

        protected virtual void UseSkill(int randomChance) { }
    }

    class Phantom : Gladiator
    {
        private int _illusionDamage = 10;
        private int _illusionCount = 3;
        private int _baseDamage;

        public Phantom(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _baseDamage = Damage;
        }

        protected override void UseSkill(int randomChance)
        {
            int illusionDamage = _illusionCount * _illusionDamage;
            int realChance = 40;

            if (realChance > randomChance)
            {
                Console.WriteLine($"{Name} создал {_illusionCount} иллюзии и нанес ими {illusionDamage} урона");
                Damage += illusionDamage;
            }
            else
            {
                Damage = _baseDamage;
            }
        }
    }

    class Knight : Gladiator
    {
        private int _maxHealth;
        private int _healthBuff = 20;

        public Knight(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _maxHealth = Health;
        }

        protected override void UseSkill(int randomChance)
        {
            int chanceAbility = 20;

            if (chanceAbility > randomChance)
            {
                if (Health + _healthBuff > _maxHealth)
                {
                    Health = _maxHealth;
                    Console.WriteLine($"{Name} помолился. Здоровье возросло до максимального уровня.");
                }
                else
                {
                    Health += _healthBuff;
                    Console.WriteLine($"{Name} помолился. Здоровье возросло на {_healthBuff} единиц.");
                }
            }
        }
    }

    class Archer : Gladiator
    {
        private int _damageBuff = 45;
        private int _baseDamage;

        public Archer(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _baseDamage = Damage;
        }

        protected override void UseSkill(int randomChance)
        {
            int chanceAbility = 30;

            if (chanceAbility > randomChance)
            {
                Console.WriteLine($"{Name} запустил ливень из стрел и нанес дополнительный урон в {_damageBuff} единиц.");
                Damage += _damageBuff;
            }
            else
            {
                Damage = _baseDamage;
            }
        }
    }

    class Healer : Gladiator
    {
        private int _maxHealth;
        private int _healthBuff = 30;

        public Healer(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _maxHealth = Health;
        }

        protected override void UseSkill(int randomChance)
        {
            int chanceAbility = 30;

            if (chanceAbility > randomChance)
            {
                if (Health + _healthBuff > _maxHealth)
                {
                    Console.WriteLine($"{Name} использовал свою силу исцеления и восстановил свой уровень здоровья до максимального.");
                    Health = _maxHealth;
                }
                else
                {
                    Console.WriteLine($"{Name} использовал свою силу исцеления и восстановил {_healthBuff} единиц здоровья.");
                    Health += _healthBuff;
                }
            }

        }
    }

    class Warrior : Gladiator
    {
        private int _baseDamage;
        private int _baseArmor;
        private int _damageBuff = 30;
        private int _armorBuff = 5;

        public Warrior(string name, int health, int damage, int armor) : base(name, health, damage, armor)
        {
            _baseArmor = Armor;
            _baseDamage = Damage;
        }

        protected override void UseSkill(int randomChance)
        {
            int chanceAbility = 25;

            if (chanceAbility > randomChance)
            {
                Console.WriteLine($"{Name} вошел в состояние берсеркаи нанес дополнительно {_damageBuff} и получил +{_armorBuff} единиц брони.");
                Damage += _damageBuff;
                Armor += _armorBuff;
            }
            else
            {
                Damage = _baseDamage;
                Armor = _baseArmor;
            }
        }
    }
}
