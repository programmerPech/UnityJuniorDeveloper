using System;
using System.Collections.Generic;

namespace DefiningDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            Dictionary<string, string> words = new Dictionary<string, string>();
            words.Add("Инкапсуляция", "является одним из ключевых понятий объектно-ориентированного программирования и представляет сокрытие состояния объекта от прямого доступа извне.");
            words.Add("Полиморфизм", "это свойство одних и тех же объектов и методов принимать разные формы.");
            words.Add("Наследование", "является одним из ключевых моментов ООП. Благодаря наследованию один класс может унаследовать функциональность другого класса.");

            while (userInput != "Выход")
            {
                Console.WriteLine("Введите слово, чтобы узнать его значение: ");
                userInput = Console.ReadLine();
                GetValue(words, userInput);
            }
        }

        static void GetValue(Dictionary<string,string> words,string word)
        {
            switch (word)
            {
                case "Инкапсуляция":
                    Console.WriteLine(words[word]);
                    break;
                case "Полиморфизм":
                    Console.WriteLine(words[word]);
                    break;
                case "Наследование":
                    Console.WriteLine(words[word]);
                    break;
                case "Выход":
                    break;
                default:
                    Console.WriteLine("Такого слова нет.");
                    break;
            }
        }
    }
}
