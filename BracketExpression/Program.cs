using System;

namespace BracketExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше выражение со скобками: ");
            string userBracketExpression = Console.ReadLine();
            char bracketSymbolOpen = '(';
            char bracketSymbolClose = ')';
            int currentDeepBracket = 0;
            int maxDeepBracket = 0;

            for(int i = 0; i < userBracketExpression.Length; i++)
            {
                if(userBracketExpression[i]== bracketSymbolOpen)
                {
                    currentDeepBracket++;

                    if(currentDeepBracket> maxDeepBracket)
                    {
                        maxDeepBracket = currentDeepBracket;
                    }
                }
                else if(userBracketExpression[i] == bracketSymbolClose && currentDeepBracket >= 0)
                {
                    currentDeepBracket--;
                }
            }

            if (currentDeepBracket == 0)
            {
                Console.WriteLine($"Скобочное выражение {userBracketExpression} является корректным и имеет максимкльную глубину вложенности скобок - {maxDeepBracket}.");
            }
            else
            {
                Console.WriteLine("Скобочное выражение является НЕкорректным.");
            }
        }
    }
}
