using System;
// 4
class Program
{
    static double TriangleArea(double x1, double y1,
                               double x2, double y2,
                               double x3, double y3)
    {
        return 0.5 * Math.Abs(
            x1 * (y2 - y3) +
            x2 * (y3 - y1) +
            x3 * (y1 - y2)
        );
    }

    static double ReadDouble(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double value))
        {
            Console.WriteLine("Ошибка ввода. Программа закрывается.");
            Environment.Exit(0);
        }

        return value;
    }

    static void Main()
    {
        Console.WriteLine("\nПервый треугольничек <3");

        double x1 = ReadDouble("Введите x1: ");
        double y1 = ReadDouble("Введите y1: ");
        double x2 = ReadDouble("Введите x2: ");
        double y2 = ReadDouble("Введите y2: ");
        double x3 = ReadDouble("Введите x3: ");
        double y3 = ReadDouble("Введите y3: ");

        double area1 = TriangleArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine("\nВторой, менее прекрасный треугольник");

        double x4 = ReadDouble("Введите x1: ");
        double y4 = ReadDouble("Введите y1: ");
        double x5 = ReadDouble("Введите x2: ");
        double y5 = ReadDouble("Введите y2: ");
        double x6 = ReadDouble("Введите x3: ");
        double y6 = ReadDouble("Введите y3: ");

        double area2 = TriangleArea(x4, y4, x5, y5, x6, y6);

        Console.WriteLine($"\nПлощадь первого треугольника: {area1:F2}");
        Console.WriteLine($"Площадь второго треугольника: {area2:F2}");

        if (area1 > area2)
        {
            Console.WriteLine("Первый треугольник больше");
        }
        else if (area2 > area1)
        {
            Console.WriteLine("Второй треугольник больше");
        }
        else
        {
            Console.WriteLine("Площади треугольников равны.");
        }
    }
}
