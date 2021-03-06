using System;

namespace MultipleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginNumberN = 1;
            int endNumberN = 27;
            int currentIndex = 0;
            int beginNumberRange = 100;
            int endNumberRange = 999;
            int firstMultipleNumber=0;
            int countNumber = 0;
            Console.WriteLine("Введите N");
            int numberN = int.Parse(Console.ReadLine());

            if (beginNumberN <= numberN && numberN <= endNumberN)
            {

                for (int index = beginNumberRange; index < endNumberRange; index++)
                {
                    currentIndex = index;

                    while (currentIndex >= 0)
                    {

                        if (currentIndex == 0)
                        {
                            firstMultipleNumber = index;
                            countNumber++;
                            break;
                        }

                        currentIndex -= numberN;
                    }
                }

                while (firstMultipleNumber + numberN <= endNumberRange)
                {
                    countNumber++;
                    firstMultipleNumber = firstMultipleNumber + numberN;
                }

                Console.WriteLine($"Количество трехзначных чисел кратных {numberN} равняется {countNumber}. ");
            }
            else 
            { 
                Console.WriteLine($"Число N должно быть от {beginNumberN} до {endNumberN}."); 
            }
        }
    }
}
