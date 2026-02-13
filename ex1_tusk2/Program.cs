using System;
// 25 задание
class Program
{
    static void Main()
    {
        int number;

        Console.WriteLine("Введите значение N:");

        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число");
        }

        int key = 1;
        while (true)
        {
            if (key > number + Math.Sqrt(number))
            {
                break;
            }
            key++;
        }

        Console.WriteLine("Минимальный возможный K: " + key);
    }
}
