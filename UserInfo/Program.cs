using System;

namespace UserInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Укажите ваш возраст: ");
            string userAge = Console.ReadLine();
            Console.WriteLine("Введите ваше любимое животное: ");
            string animalKind = Console.ReadLine();
            Console.WriteLine("Укажите ваш любимый музыкальный жанр: ");
            string musicGenre = Console.ReadLine();
            Console.WriteLine("Вас зовут " + userName + ", ваш возраст -  " + userAge + ", ваше любимое животное: " + animalKind + ", и вы слушаете " + musicGenre + ".");
        }
    }
}
