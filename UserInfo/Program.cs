using System;

namespace UserInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string userName = Console.ReadLine();
            Console.Write("Укажите ваш возраст: ");
            int userAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ваше любимое животное: ");
            string animalKind = Console.ReadLine();
            Console.Write("Укажите ваш любимый музыкальный жанр: ");
            string musicGenre = Console.ReadLine();
            Console.Write($"Вас зовут {userName}, ваш возраст - {userAge}, ваше любимое животное: {animalKind} и вы слушаете {musicGenre}.");
        }
    }
}
