using System;
using System.Diagnostics;
// 25
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");

        string input = Console.ReadLine();

        if (input.Length == 0)
        {
            Console.WriteLine("Ошибка! строка пустая");
            return;
        }

        // всего слов
        int wordCount = 0;
        bool inWord = false;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ' && !inWord)
            {
                wordCount++;
                inWord = true;
            }
            else if (input[i] == ' ')
            {
                inWord = false;
            }
        }

        // заполняем массив словами
        string[] words = new string[wordCount];

        int index = 0;
        inWord = false;
        string currentWord = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != ' ')
            {
                currentWord += input[i];
                inWord = true;
            }
            else
            {
                if (inWord)
                {
                    words[index] = currentWord;
                    index++;
                    currentWord = "";
                    inWord = false;
                }
            }
        }

        // забыл последнее слово?
        if (currentWord.Length > 0)
        {
            words[index] = currentWord;
        }

        // пузырьковая сортировка
        for (int i = 0; i < words.Length - 1; i++)
        {
            for (int j = 0; j < words.Length - i - 1; j++)
            {
                if (words[j].Length > words[j + 1].Length)
                {
                    string temp = words[j];
                    words[j] = words[j + 1];
                    words[j + 1] = temp;
                }
            }
        }

        // вывод всех слов + длина 
        Console.WriteLine("\nСлова, отсортированные по длине и усталости:");


        if (words.Length == 0)
        {
            Console.WriteLine("Ошибка! Строка состоит только из пустых символов.");
            return; 
        }
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {words[i]} (длина: {words[i].Length})");
        }
    }
}
