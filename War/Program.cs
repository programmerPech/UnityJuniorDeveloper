using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstSoldiersCount;
            int secondSoldiersCount;
            Console.WriteLine("Добро пожаловать на симуляцию командного боя.\nВведите количество солдат первого взвода: ");
            bool isFirstNumber = Int32.TryParse(Console.ReadLine(), out firstSoldiersCount);
            Console.WriteLine("Введите количество солдат второго взвода: ");
            bool isSecondNumber = Int32.TryParse(Console.ReadLine(), out secondSoldiersCount);

            while (isFirstNumber != true && isSecondNumber != true)
            {
                Console.WriteLine("Ошибка в создании взводов. Ожидалось число! Повторите попытку: ");
                Console.WriteLine("Добро пожаловать на симуляцию командного боя.\nВведите количество солдат первого взвода: ");
                isFirstNumber = Int32.TryParse(Console.ReadLine(), out firstSoldiersCount);
                Console.WriteLine("Введите количество солдат второго взвода: ");
                isSecondNumber = Int32.TryParse(Console.ReadLine(), out secondSoldiersCount);
            }

            Battle battle = new Battle();
            battle.Start(firstSoldiersCount, secondSoldiersCount);
            battle.ShowResults();
        }
    }

    class Battle
    {
        private Platoon _firstPlatoon;
        private Platoon _secondPlatoon;
        private Random _random = new Random();
        private Soldier _firstSoldier;
        private Soldier _secondSoldier;

        public void Start(int firstSoldiersCount, int secondSoldiersCount)
        {
            _firstPlatoon = new Platoon(firstSoldiersCount, _random);
            _secondPlatoon = new Platoon(secondSoldiersCount, _random);

            while (_firstPlatoon.GetSoldiersCount() > 0 && _secondPlatoon.GetSoldiersCount() > 0)
            {
                _firstSoldier = _firstPlatoon.GetCurrentSoldier(_random);
                _secondSoldier = _secondPlatoon.GetCurrentSoldier(_random);
                Console.WriteLine("Способность солдата из первого взвода: ");
                _firstSoldier.UseSpecialAbility(_random);
                Console.WriteLine("Способность солдата из второго взвода: ");
                _secondSoldier.UseSpecialAbility(_random);
                Console.WriteLine();
                _firstPlatoon.ShowInfo();
                Console.WriteLine();
                _secondPlatoon.ShowInfo();
                Console.WriteLine();
                _firstSoldier.TakeDamage(_secondSoldier.Damage);
                _secondSoldier.TakeDamage(_firstSoldier.Damage);
                DeleteDiedSoldiers();
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ShowResults()
        {
            if (_firstPlatoon.GetSoldiersCount() == 0 && _secondPlatoon.GetSoldiersCount() == 0)
            {
                Console.WriteLine($"Результат боя - ничья.");
                Console.WriteLine($"Первый взвод - {_firstPlatoon.GetSoldiersCount()}. Второй взвод - {_secondPlatoon.GetSoldiersCount()}");

            }
            else if (_firstPlatoon.GetSoldiersCount() <= 0)
            {
                Console.WriteLine("Второй взвод победил.");
                Console.WriteLine($"Первый взвод - {_firstPlatoon.GetSoldiersCount()}. Второй взвод - {_secondPlatoon.GetSoldiersCount()}");
            }
            else if (_secondPlatoon.GetSoldiersCount() <= 0)
            {
                Console.WriteLine("Первый взвод победил.");
                Console.WriteLine($"Первый взвод - {_firstPlatoon.GetSoldiersCount()}. Второй взвод - {_secondPlatoon.GetSoldiersCount()}");
            }
        }

        private void DeleteDiedSoldiers()
        {
            if (_firstSoldier.Health <= 0)
            {
                _firstPlatoon.DeleteSoldier(_firstSoldier);
            }

            if (_secondSoldier.Health <= 0)
            {
                _secondPlatoon.DeleteSoldier(_secondSoldier);
            }
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers = new List<Soldier>();

        public Platoon(int soldiersCount, Random random)
        {
            Create(soldiersCount, _soldiers, random);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Информация о взводе");

            foreach (var soldier in _soldiers)
            {
                Console.WriteLine($"{soldier.Name}. Урон: {soldier.Damage}. Здоровье: {soldier.Health}. Броня: {soldier.Armor}");
            }
        }

        public void DeleteSoldier(Soldier soldier)
        {
            _soldiers.Remove(soldier);
        }

        public Soldier GetCurrentSoldier(Random random)
        {
            int minimalCount = 0;
            return _soldiers[random.Next(minimalCount, _soldiers.Count)];
        }

        public int GetSoldiersCount()
        {
            return _soldiers.Count;
        }

        private void Create(int soldiersCount, List<Soldier> soldiers, Random random)
        {
            for (int i = 0; i < soldiersCount; i++)
            {
                soldiers.Add(GetNewSoldier
                    
                    (random));
            }
        }

        private Soldier GetNewSoldier(Random random)
        {
            int minimumCountClassSoldier = 0;
            int maximumCountClassSoldier = 4;
            int soldierClassNumber = random.Next(minimumCountClassSoldier, maximumCountClassSoldier);

            switch (soldierClassNumber)
            {
                case 0:
                    return new Sniper("Снайпер", 40, 100, 10);
                case 1:
                    return new Medic("Медик", 25, 125, 20);
                case 2:
                    return new Bomber("Подрывник", 50, 75, 30);
                case 3:
                    return new Stormtrooper("Штурмовик", 35, 130, 25);
                default:
                    return null;
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public int Damage { get; protected set; }
        public int Health { get; protected set; }
        public int Armor { get; protected set; }

        public Soldier(string name, int damage, int health, int armor)
        {
            Name = name;
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public void TakeDamage(int damage)
        {
            int maximumBlockedDamage = 100;
            int totalDamage = damage * (maximumBlockedDamage - Armor) / maximumBlockedDamage;
            Health -= totalDamage;
            Console.WriteLine($"{Name} получил {totalDamage} урона");
        }

        public void UseSpecialAbility(Random random)
        {
            double chance = random.NextDouble();
            UseSkill(chance);
        }

        protected virtual void UseSkill(double chance) { }
    }

    class Sniper : Soldier
    {
        private int _damageUp = 10;
        private int _baseDamage;

        public Sniper(string name, int damage, int health, int armor) : base(name, damage, health, armor)
        {
            _baseDamage = Damage;
        }

        protected override void UseSkill(double chance)
        {
            double realChance = 0.2;

            if (realChance > chance)
            {
                Console.WriteLine($"{Name} стреляет в более уязвимые места +{_damageUp} к урону.");
            }
            else
            {
                Damage = _baseDamage;
            }
        }
    }

    class Medic : Soldier
    {
        private int _healthUp = 25;
        private int _baseHealth;

        public Medic(string name, int damage, int health, int armor) : base(name, damage, health, armor)
        {
            _baseHealth = health;
        }

        protected override void UseSkill(double chance)
        {
            double realChance = 0.12;

            if (realChance > chance)
            {
                Console.WriteLine($"{Name} делает себе перевязку ран +{_healthUp} к здоровью.");

                if (_baseHealth <= (Health + _healthUp))
                {
                    Health += _healthUp;
                }
                else
                {
                    Health = _baseHealth;
                }
            }
        }
    }

    class Bomber : Soldier
    {
        private int _damageUp = 50;
        private int _baseDamage;

        public Bomber(string name, int damage, int health, int armor) : base(name, damage, health, armor)
        {
            _baseDamage = Damage;
        }

        protected override void UseSkill(double chance)
        {
            double realChance = 0.1;

            if (realChance > chance)
            {
                Console.WriteLine($"{Name} подорвал противника на мине +{_damageUp} к урону.");
                Damage += _damageUp;
            }
            else
            {
                Damage = _baseDamage;
            }
        }
    }

    class Stormtrooper : Soldier
    {
        private int _damageUp = 15;
        private int _baseDamage;
        private int _armorUp = 10;
        private int _baseArmor;

        public Stormtrooper(string name, int damage, int health, int armor) : base(name, damage, health, armor)
        {
            _baseArmor = Armor;
            _baseDamage = Damage;
        }

        protected override void UseSkill(double chance)
        {
            double realChance = 0.2;

            if (realChance > chance)
            {
                Console.WriteLine($"{Name} входит в состояние берсерка и наносит на {_damageUp} больше урона и получает +{_armorUp} к броне.");
                Damage += _damageUp;
                Armor += _armorUp;
            }
            else
            {
                Damage = _baseArmor;
                Armor = _baseDamage;
            }

        }
    }
}
