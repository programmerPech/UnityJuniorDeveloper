using System;

namespace SplitText
{
    class Program
    {
        static void Main(string[] args)
        {
            string textString = "Съешь ещё этих мягких французских булок да выпей чаю";
            string[] wordArray = textString.Split(' ');

            Console.WriteLine(textString);

            foreach (string word in wordArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}
