using System;


// 25 задание
class Program
{
    static void Main()
    {
        int quantity;

        Console.WriteLine("Введите кол-во переменных для подсчета произведения:");

        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число:");
        }

        int product = 1;

        for (int i = 0; i < quantity; i++)
        {
            int number;

            Console.WriteLine($"Осталось ввести чисел: {quantity - i}");
            Console.WriteLine("Введите целое положительное число:");

            while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
            {
                Console.WriteLine("Ошибка! Введите целое положительное число:");
            }

            product *= number;
        }

        Console.WriteLine($"\nРезультат: {product}");
    }
}
