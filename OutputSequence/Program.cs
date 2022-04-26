using System;

namespace OutputSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginSequence = 5;
            int endSequence = 96;
            int stepSequence = 7;

            for(int i = beginSequence; i<=endSequence; i+=stepSequence)
            {
                Console.Write(i+" ");
            }
        }
    }
}
