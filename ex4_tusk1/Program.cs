using System;

class Program
{
    static void Main()
    {
        // массив символов вместо строки
        char[] text = { 'h', 'e', 'l', 'l', 'o', ' ', 'm', 'y', ' ', 'd', 'e', 'a', 'r', ' ', 'w', 'o', 'r', 'l', 'd' };

        int wordCount = 0;
        bool inWord = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ' && !inWord)
            {
                wordCount++;
                inWord = true;
            }
            else if (text[i] == ' ')
            {
                inWord = false;
            }
        }

        if (wordCount == 0)
        {
            Console.WriteLine("Ошибка! Нет слов.");
            return;
        }

        // заполняем массив словами
        string[] words = new string[wordCount];

        int index = 0;
        inWord = false;
        string currentWord = "";

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] != ' ')
            {
                currentWord += text[i];
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

        Console.WriteLine("Слова, отсортированные по длине:");
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {words[i]} (длина: {words[i].Length})");
        }
    }
}
