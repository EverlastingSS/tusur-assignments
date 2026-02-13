using System;
// 25 задание
class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Ошибка! Некорректное количество элементов.");
            return;
        }

        double[] arr = new double[n];

        Console.WriteLine("Введите элементы массива (каждый, на новой строке):");
        for (int i = 0; i < n; i++)
        {
            if (!double.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.WriteLine("Ошибка! Некорректный ввод элемента массива.");
                return;
            }
        }

        // минимальный
        double min = arr[0];
        for (int i = 1; i < n; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        // до первого положительного
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0)
                break;

            sum += arr[i];
        }

        Console.WriteLine("Введите границы интервала(a и b), каждый на новой строке:");

        if (!double.TryParse(Console.ReadLine(), out double a) ||
            !double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Ошибка! Некорректный ввод интервала.");
            return;
        }

        if (a > b)
        {
            Console.WriteLine("Ошибка! Значение a должно быть меньше или равно b.");
            return;
        }

        // Сжатие массива
        double[] newArr = new double[n];
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            double absValue = Math.Abs(arr[i]);

            if (absValue < a || absValue > b)
            {
                newArr[index] = arr[i];
                index++;
            }
        }

        Console.WriteLine("\nМинимальный элемент: " + min);
        Console.WriteLine("Сумма до первого положительного: " + sum);

        Console.WriteLine("Массив после сжатия:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(newArr[i] + " ");
        }
    }
}
