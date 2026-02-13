using System;
// 4
class Program
{
    // по ощущениям рекурсия не нужна
    static int SumDigitsRecursive(string str, int index)
    {
       
        if (index >= str.Length)
            return 0;

        int current = 0;

        if (str[index] >= '0' && str[index] <= '9')
        {
            current = str[index] - '0';
        }

        return current + SumDigitsRecursive(str, index + 1);
    }

    static void Main()
    {
        Console.Write("Введите вещественное число: ");
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double number))
        {
            Console.WriteLine("Ошибка ввода. Программа закрывается.");
            Environment.Exit(0);
        }

        int sum = SumDigitsRecursive(input, 0);

        Console.WriteLine("Сумма цифр: " + sum);
    }
}
