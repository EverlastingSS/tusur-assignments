using System;
// 4 zadanie
interface IOperations
{
    Money Add(Money other);
    Money Subtract(Money other);
    Money Multiply(double number);
    Money DivideByNumber(double number);
    int CompareToNumber(double number);
}

abstract class Value
{
    public abstract void Print();
}

class Money : Value, IOperations
{
    private long rubles;
    private int kopecks;

    public Money(long rubles, int kopecks)
    {
        this.rubles = rubles;
        this.kopecks = kopecks;
        Normalize();
    }

    ~Money()
    {
        Console.WriteLine("Объект Money уничтожен");
    }

    private void Normalize()
    {
        if (kopecks >= 100)
        {
            rubles += kopecks / 100;
            kopecks = kopecks % 100;
        }
        else if (kopecks < 0)
        {
            rubles -= 1;
            kopecks += 100;
        }
    }

    private double ToDouble()
    {
        return rubles + kopecks / 100.0;
    }

    public override void Print()
    {
        Console.WriteLine($"{rubles},{kopecks:D2}");
    }

    public Money Add(Money other)
    {
        return new Money(rubles + other.rubles, kopecks + other.kopecks);
    }

    public Money Subtract(Money other)
    {
        return new Money(rubles - other.rubles, kopecks - other.kopecks);
    }

    public Money Multiply(double number)
    {
        double result = ToDouble() * number;
        long r = (long)result;
        int k = (int)((result - r) * 100);
        return new Money(r, k);
    }

    public Money DivideByNumber(double number)
    {
        if (number == 0)
        {
            Console.WriteLine("Ошибка: деление на ноль невозможно!");
            return this;
        }

        double result = ToDouble() / number;
        long r = (long)result;
        int k = (int)((result - r) * 100);
        return new Money(r, k);
    }

    public int CompareToNumber(double number)
    {
        double total = ToDouble();

        if (total > number) return 1;
        if (total < number) return -1;
        return 0;
    }
}

class Program
{
    static int ReadInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Ошибка! Введите целое число.");
        }
    }

    static long ReadLong(string message)
    {
        long value;
        while (true)
        {
            Console.Write(message);
            if (long.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Ошибка! Введите целое число.");
        }
    }

    static double ReadDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            if (double.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine("Ошибка! Введите число.");
        }
    }

    static Money InputMoney(string message)
    {
        Console.WriteLine(message);

        long r = ReadLong("Рубли: ");
        int k = ReadInt("Копейки: ");

        return new Money(r, k);
    }

    static void Main()
    {
        Money m1 = InputMoney("Введите первую сумму денег:");
        Money m2 = InputMoney("Введите вторую сумму:");

        Money current = null;

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("1 - Найти сумму первоначального ввода");
            Console.WriteLine("2 - Найти разность первоначального ввода");
            Console.WriteLine("3 - Умножить текущую сумму денег на дробное число");
            Console.WriteLine("4 - Разделить текущую сумму денег на дробное число");
            Console.WriteLine("5 - Сравнить текущую сумму денег с дробным числом");
            Console.WriteLine("6 - Показать текущую сумму денег");
            Console.WriteLine("0 - Выход");

            int choice = ReadInt("Выберите пункт: ");

            if (choice == 0)
                break;

            switch (choice)
            {
                case 1:
                    current = m1.Add(m2);
                    Console.Write("Сумма: ");
                    current.Print();
                    break;

                case 2:
                    current = m1.Subtract(m2);
                    Console.Write("Разность: ");
                    current.Print();
                    break;

                case 3:
                    if (current == null)
                    {
                        Console.WriteLine("Сначала нужно получить сумму или разность.");
                        break;
                    }
                    double num1 = ReadDouble("Введите дробное число: ");
                    current = current.Multiply(num1);
                    Console.Write("Результат: ");
                    current.Print();
                    break;

                case 4:
                    if (current == null)
                    {
                        Console.WriteLine("Сначала нужно получить сумму или разность.");
                        break;
                    }
                    double num2 = ReadDouble("Введите дробное число: ");

                    if (num2 == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль невозможно!");
                        break;
                    }

                    current = current.DivideByNumber(num2);
                    Console.Write("Результат: ");
                    current.Print();
                    break;

                case 5:
                    if (current == null)
                    {
                        Console.WriteLine("Сначала нужно получить сумму или разность.");
                        break;
                    }
                    double num3 = ReadDouble("Введите дробное число (копейки после знака {.}): ");

                    int cmp = current.CompareToNumber(num3);

                    if (cmp > 0)
                        Console.WriteLine("Текущая сумма больше числа");
                    else if (cmp < 0)
                        Console.WriteLine("Текущая сумма меньше числа");
                    else
                        Console.WriteLine("Они равны");
                    break;

                case 6:
                    if (current == null)
                        Console.WriteLine("Текущая сумма ещё не вычислена.");
                    else
                        current.Print();
                    break;

                default:
                    Console.WriteLine("Неверный пункт меню");
                    break;
            }
        }

        Console.WriteLine("Программа завершена");
    }
}
