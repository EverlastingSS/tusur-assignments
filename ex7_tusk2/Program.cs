using System;
using System.Globalization;
// zadanie 4
class Goods
{
    private string name;
    private DateTime date;
    private double price;
    private int quantity;
    private string invoiceNumber;

    // конструктор
    public Goods(string name, DateTime date, double price, int quantity, string invoiceNumber)
    {
        this.name = name;
        this.date = date;
        this.price = price;
        this.quantity = quantity;
        this.invoiceNumber = invoiceNumber;
    }

    // деконструктор
    ~Goods()
    {
        Console.WriteLine("Объект Goods удален");
    }

    
    public void ChangePrice(double newPrice)
    {
        if (newPrice < 0)
        {
            Console.WriteLine("Цена не может быть отрицательной.");
            return;
        }

        price = newPrice;
        Console.WriteLine("Цена успешно изменена.");
    }

    // + колво
    public void IncreaseQuantity(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            return;
        }

        quantity += amount;
        Console.WriteLine("Количество увеличено.");
    }

    // - колво
    public void DecreaseQuantity(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Количество должно быть больше 0.");
            return;
        }

        if (amount > quantity)
        {
            Console.WriteLine("Недостаточно товара на складе.");
            return;
        }

        quantity -= amount;
        Console.WriteLine("Количество уменьшено.");
    }

    // тотал 
    public double CalculateTotalCost()
    {
        return price * quantity;
    }

    // стоимость как строка
    public string GetTotalCostString()
    {
        return "Общая стоимость: " + CalculateTotalCost() + " руб.";
    }

    public void PrintInfo()
    {
        Console.WriteLine("\nИнформация о товаре:");
        Console.WriteLine("Название: " + name);
        Console.WriteLine("Дата оформления: " + date.ToShortDateString());
        Console.WriteLine("Цена: " + price + " руб.");
        Console.WriteLine("Количество: " + quantity);
        Console.WriteLine("Номер накладной: " + invoiceNumber);
        Console.WriteLine(GetTotalCostString());
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

    static DateTime ReadDate(string message)
    {
        DateTime value;
        while (true)
        {
            Console.Write(message + " (формат: дд.мм.гггг): ");
            string input = Console.ReadLine();

            if (DateTime.TryParseExact(
                input,
                "dd.MM.yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out value))
            {
                return value;
            }

            Console.WriteLine("Ошибка! Введите дату в формате дд.мм.гггг");
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите данные о товаре:");

        Console.Write("Название товара: ");
        string name = Console.ReadLine();

        DateTime date = ReadDate("Дата оформления: ");

        double price;
        while (true)
        {
            price = ReadDouble("Цена товара: ");
            if (price >= 0) break;
            Console.WriteLine("Цена не может быть отрицательной.");
        }

        int quantity;
        while (true)
        {
            quantity = ReadInt("Количество: ");
            if (quantity >= 0) break;
            Console.WriteLine("Количество не может быть отрицательным.");
        }

        Console.Write("Номер накладной: ");
        string invoice = Console.ReadLine();

        Goods goods = new Goods(name, date, price, quantity, invoice);

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("1 - Изменить цену");
            Console.WriteLine("2 - Увеличить количество");
            Console.WriteLine("3 - Уменьшить количество");
            Console.WriteLine("4 - Показать информацию о товаре");
            Console.WriteLine("0 - Выход");

            int choice = ReadInt("Выберите пункт: ");

            if (choice == 0)
                break;

            switch (choice)
            {
                case 1:
                    double newPrice = ReadDouble("Введите новую цену: ");
                    goods.ChangePrice(newPrice);
                    break;

                case 2:
                    int add = ReadInt("Введите количество для увеличения: ");
                    goods.IncreaseQuantity(add);
                    break;

                case 3:
                    int remove = ReadInt("Введите количество для уменьшения: ");
                    goods.DecreaseQuantity(remove);
                    break;

                case 4:
                    goods.PrintInfo();
                    break;

                default:
                    Console.WriteLine("Неверный пункт меню.");
                    break;
            }
        }

        Console.WriteLine("Программа завершена.");
    }
}
