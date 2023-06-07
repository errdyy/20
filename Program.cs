using System;

class Program
{
    static void Main()
    {
        int[,] matrix = new int[3, 3];

        CompleteMatrix(matrix);
        Console.WriteLine("Заполненный массив:");
        PrintMatrix(matrix);

        bool isMagicSquare = IsMagicSquare(matrix);
        if (isMagicSquare)
        {
            Console.WriteLine("Массив является магическим квадратом.");//такой вообще есть?
        }
        else
        {
            Console.WriteLine("Массив не является магическим квадратом.");
        }

        Console.ReadLine();
    }

    static void CompleteMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int totalN = size * size;
        bool[] usedN = new bool[totalN + 1];//по идее самый оптимизированный способ проверки

        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int number;
                do
                {
                    number = random.Next(1, totalN + 1);
                } while (usedN[number]);

                matrix[i, j] = number;
                usedN[number] = true;
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static bool IsMagicSquare(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int magicSum = size * (size * size + 1) / 2;


        for (int i = 0; i < size; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < size; j++)
            {
                rowSum += matrix[i, j];
            }
            if (rowSum != magicSum)
            {
                return false;
            }
        }


        for (int j = 0; j < size; j++)
        {
            int columnSum = 0;
            for (int i = 0; i < size; i++)
            {
                columnSum += matrix[i, j];
            }
            if (columnSum != magicSum)
            {
                return false;
            }
        }


        int diagSum1 = 0;
        int diagSum2 = 0;
        for (int i = 0; i < size; i++)
        {
            diagSum1 += matrix[i, i];
            diagSum2 += matrix[i, size - i - 1];
        }
        if (diagSum1 != magicSum || diagSum2 != magicSum)
        {
            return false;
        }

        return true;
    }
}
