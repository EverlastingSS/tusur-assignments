using System;
// 25
class Program
{
    static void Main()
    {
        Console.WriteLine("КЛАВИАТУРНЫЙ ТРЕНАЖЕР ОТ ТУСУР!!!\n\n");
        Console.WriteLine("Выберите язык:");
        Console.WriteLine("1 - Русский");
        Console.WriteLine("2 - Английский");

        char languageChoice = Console.ReadKey(true).KeyChar;
        Console.WriteLine();

        string symbols = "";

        if (languageChoice == '1')
        {
            symbols = "абвгдежзийклмнопрстуфхцчшщыэюя";
            Console.WriteLine("Выбран русский язык.");
        }
        else if (languageChoice == '2')
        {
            symbols = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("Выбран английский язык.");
        }
        else
        {
            Console.WriteLine("Ошибка выбора языка. Завершение программы");
            return;
        }

        Console.WriteLine("Для выхода нажмите ESC.\n");


        Random random = new Random();
        int correctCount = 0;

        while (true)
        {
            int index = random.Next(0, symbols.Length);
            char generatedChar = symbols[index];

            Console.WriteLine("Введите символ: " + generatedChar);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }

            char userChar = keyInfo.KeyChar;

            if (userChar == generatedChar)
            {
                correctCount++;
                Console.WriteLine("Верно! Текущий счёт: " + correctCount);
            }
            else
            {
                correctCount = 0;
                Console.Beep(); // бип-бип! Сбиты.
                Console.WriteLine("Ошибка! Счёт обнулён. Попробуй еще раз :)");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Тренировка завершена.");
        Console.WriteLine("Максимальное количество подряд введённых символов: " + correctCount);
    }
}
