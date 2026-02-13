using System;
// 25
class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        if (!int.TryParse(Console.ReadLine(), out int rows) || rows <= 0)
        {
            Console.WriteLine("Ошибка! Некорректное кол-во строк.");
            return;
        }

        Console.Write("Введите количество столбцов: ");
        if (!int.TryParse(Console.ReadLine(), out int cols) || cols <= 0)
        {
            Console.WriteLine("Ошибка! Некорректное кол-во столбцов.");
            return;
        }

        double[,] matrix = new double[rows, cols];

        Console.WriteLine("Введите элементы матрицы по одному:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (!double.TryParse(Console.ReadLine(), out matrix[i, j]))
                {
                    Console.WriteLine("Ошибка! Некорректный ввод элемента.");
                    return;
                }
            }
        }

        Console.Write("Введите номера двух строк для обмена (нумерация с 1) через пробел: ");
        string[] parts = Console.ReadLine().Split(' ');

        if (parts.Length != 2 ||
            !int.TryParse(parts[0], out int row1) ||
            !int.TryParse(parts[1], out int row2))
        {
            Console.WriteLine("Ошибка! Некорректный ввод номеров строк.");
            return;
        }

        if (row1 < 1 || row1 > rows || row2 < 1 || row2 > rows)
        {
            Console.WriteLine("Ошибка! Номера строк вне диапазона.");
            return;
        }


        row1--;
        row2--;

        for (int j = 0; j < cols; j++)
        {
            double temp = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp;
        }

        Console.WriteLine("Матрица после обмена строк:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
