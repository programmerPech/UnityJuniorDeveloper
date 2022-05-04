using System;

namespace MaxElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = 10;
            int columnsCount = 10;
            int[,] matrixA = new int[rowsCount, columnsCount];
            Random random = new Random();
            int beginRandomRange = 0;
            int endRandomRange = 10;
            int maxElement = Int32.MinValue;
            int replacingElement = 0;

            Console.WriteLine("Исходная матрица:");

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for(int j=0;j<matrixA.GetLength(1); j++)
                {
                    matrixA[i, j] = random.Next(beginRandomRange, endRandomRange);
                    Console.Write(matrixA[i, j] + " ");

                    if (maxElement < matrixA[i, j])
                        maxElement = matrixA[i, j];
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Максимальный элемент массива - {maxElement}.");
            Console.WriteLine("Получившаяся матрица:");

            for(int i=0;i<matrixA.GetLength(0); i++)
            {
                for(int j=0; j<matrixA.GetLength(1); j++)
                {
                    if (matrixA[i, j] == maxElement)
                        matrixA[i, j] = replacingElement;

                    Console.Write(matrixA[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
