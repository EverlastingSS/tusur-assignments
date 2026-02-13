using System;
// 25
struct Student
{
    public string LastName;
    public string FirstName;
    public int ClassNumber;
    public int Grade1;
    public int Grade2;
    public int Grade3;
}

class Program
{
    static Random random = new Random();

    static void Main()
    {
        Student[] students = new Student[10];

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"\nЗапись человека номер: {i + 1}");
            Console.WriteLine("1 - Сгенерировать");
            Console.WriteLine("2 - Ввести вручную");

            int choice = ReadIntInRange("Ваш выбор: ", 1, 2);

            if (choice == 1)
                students[i] = GenerateStudent(i);
            else
                students[i] = InputStudent();
        }

        Console.WriteLine("\nСписок учащихся со средним баллом:\n");

        for (int i = 0; i < students.Length; i++)
        {
            double average = (students[i].Grade1 +
                              students[i].Grade2 +
                              students[i].Grade3) / 3.0;

            Console.WriteLine($"{i + 1}. {students[i].LastName} {students[i].FirstName}, " +
                              $"класс {students[i].ClassNumber}, " +
                              $"средний балл: {average:F2}");
        }
    }

    static Student GenerateStudent(int index)
    {
        string[] lastNames = { "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко", "Алексеенко" };
        string[] firstNames = { "Евгений", "Екатерина", "Юрий", "Наталья", "Сергей", "Пудж", "Арк", "Инвокер", "Мипо", "Пак" };

        Student s = new Student();
        s.LastName = lastNames[index];
        s.FirstName = firstNames[index];
        s.ClassNumber = random.Next(1, 12); 
        s.Grade1 = random.Next(2, 6); 
        s.Grade2 = random.Next(2, 6);
        s.Grade3 = random.Next(2, 6);

        return s;
    }

    static Student InputStudent()
    {
        Student s = new Student();

        Console.Write("Фамилия: ");
        s.LastName = Console.ReadLine();

        Console.Write("Имя: ");
        s.FirstName = Console.ReadLine();

        s.ClassNumber = ReadIntInRange("Номер класса (1-11): ", 1, 11);
        s.Grade1 = ReadIntInRange("Оценка 1 (2-5): ", 2, 5);
        s.Grade2 = ReadIntInRange("Оценка 2 (2-5): ", 2, 5);
        s.Grade3 = ReadIntInRange("Оценка 3 (2-5): ", 2, 5);

        return s;
    }

    static int ReadIntInRange(string message, int min, int max)
    {
        int value;

        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out value))
            {
                if (value >= min && value <= max)
                {
                    return value; 
                }
                else
                {
                    Console.WriteLine("Число вне допустимого диапазона.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Введите число.");
            }
        // while(true) { кодим }
        }
    }
}
