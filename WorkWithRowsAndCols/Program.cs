using System;

namespace WorkWithRowsAndCols
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = 5;
            int columnsCount = 5;
            int[,] twoDimensionalArray = new int[rowsCount, columnsCount];
            int rowNumber = 2;
            int colummNumber = 1;
            int beginRandomRange = 0;
            int endRandomRange = 10;
            int resultSumRow = 0;
            int resultProductColumn = 1;
            Random random = new Random();

            Console.WriteLine("Исходная матрица:");

            for(int i=0; i<twoDimensionalArray.GetLength(0); i++)
            {
                for(int j=0;j<twoDimensionalArray.GetLength(1); j++)
                {
                    twoDimensionalArray[i, j] = random.Next(beginRandomRange, endRandomRange);
                    Console.Write(twoDimensionalArray[i, j] + " ");

                    if (i == rowNumber-1)
                    {
                        resultSumRow += twoDimensionalArray[i, j];
                    }

                    if (j == colummNumber-1)
                    {
                        resultProductColumn *= twoDimensionalArray[i, j];
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Сумма {rowNumber} строки равна {resultSumRow}.");
            Console.WriteLine($"Произведение {colummNumber} столбца равно {resultProductColumn}.");
        }
    }
}
