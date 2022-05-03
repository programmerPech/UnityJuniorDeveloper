using System;

namespace BossFight
{
    class Program
    {
        static void Main(string[] args)
        {
            float healthMage = 1000;
            float maxHealthMage = 1000;
            int healthBoss = 1500;
            Random random = new Random();
            int minDamageBoss = 100;
            int maxDamageBoss = 300;
            int damageBoss = random.Next(minDamageBoss, maxDamageBoss);
            bool spiritIsAlive = false;
            bool usedDimensionalRift = false;
            float needHealthPercentForLastDance = 40f;
            int maxPercent = 100;
            int fireballCount = 0;
            int minFireballCount = 1;
            int maxFireballCount = 4;
            int oneFireballDamage = 200;
            int fireballsDamage = 0;
            Console.WriteLine("Здравствуй, теневой маг! Перед тобой стоит босс, ты должен его уничтожить!");
            Console.WriteLine("У тебя есть 4 заклинания:\n1. Рашамон-призывает теневого духа и отнимает вам 100хп.");
            Console.WriteLine("2. Хуганзакура (Может быть выполнен только после призыва теневого духа), наносит 100 ед. урона.");
            Console.WriteLine("3. Межпространственный разлом – позволяет скрыться в разломе и восстановить 250хп. Урон босса по вам не проходит");
            Console.WriteLine($"4. Последний танец - посылает от 1 до 3 фаерболов, которые наносят по 200 ед. урона каждый. Можно использовать только если у вас меньше {needHealthPercentForLastDance}% от уровня максимального здоровья."); 

            while (healthBoss > 0 && healthMage > 0)
            {
                Console.Write("Выберите заклинание (цифры от 1 до 4): ");
                string userChoiceSpell = Console.ReadLine();

                switch (userChoiceSpell)
                {
                    case "1":
                        spiritIsAlive = true;
                        healthMage -= 100;
                        usedDimensionalRift = false;
                        break;
                    case "2":
                        usedDimensionalRift = false;

                        if (spiritIsAlive == true)
                        {
                            healthBoss -= 100;
                        }
                        else
                        {
                            Console.WriteLine("У вас не призван теневой дух, используйте первое заклинание Рашамон.");
                        }

                        break;
                    case "3":
                        usedDimensionalRift = true;
                        healthMage += 250;

                        if (healthMage > maxHealthMage)
                            healthMage = maxHealthMage;

                        break;
                    case "4":
                        usedDimensionalRift = false;

                        if (healthMage < needHealthPercentForLastDance/maxPercent * maxHealthMage)
                        {
                            fireballCount = random.Next(minFireballCount, maxFireballCount);
                            fireballsDamage = oneFireballDamage * fireballCount;
                            healthBoss -= fireballsDamage;
                            Console.WriteLine($"Вы скастовали {fireballCount} фаербол(а) и он(и) нанес(ли) {fireballsDamage} ед. урона боссу");
                        }
                        else
                        {
                            Console.WriteLine($"Вы не можете использовать заклинание. У вас должно быть меньше {needHealthPercentForLastDance}% от максимального уровня здоровья. Недостаточно низкий уровень здоровья.");
                        }

                        break;
                    default:
                        usedDimensionalRift = false;
                        Console.WriteLine("Неизвестное заклинание.");
                        break;
                }

                if (usedDimensionalRift == false)
                {
                    healthMage -= damageBoss;
                }

                Console.WriteLine("Итоги раунда: ваше хп равняется " + healthMage + " здоровье босса " + healthBoss);
            }

            if (healthMage <= 0 && healthBoss <= 0)
            {
                Console.WriteLine("Бой закончился ничьей.");
            }
            else if (healthMage <= 0)
            {
                Console.WriteLine("Вы погибли");
            }
            else if (healthBoss <= 0)
            {
                Console.WriteLine("Босс повержен");
            }
        }
    }
}
