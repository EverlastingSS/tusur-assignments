using System;
using System.Collections.Generic;
class TaskItem
{
    public int Id;
    public string Title;
    public int Priority;
    public TaskItem(int id, string title, int priority)
    {
        Id = id;
        Title = title;
        Priority = priority;}
    public override string ToString()
    {
        return $"ID: {Id}, Название: {Title}, Приоритет: {Priority}";}}
class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();
    static Stack<List<TaskItem>> history = new Stack<List<TaskItem>>();
    static int nextId = 1;
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Изменить приоритет");
            Console.WriteLine("4. Показать все задачи");
            Console.WriteLine("5. Выполнить следующую задачу");
            Console.WriteLine("6. Отменить последнее изменение");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddTask(); break;
                case "2": RemoveTask(); break;
                case "3": ChangePriority(); break;
                case "4": ShowTasks(); break;
                case "5": ExecuteTask(); break;
                case "6": Undo(); break;
                case "0": return;
                default: Console.WriteLine("Неверный выбор."); break;}}}
    static void SaveState()
    {
        history.Push(new List<TaskItem>(tasks));}
    static bool IsEnglish(string text)
    {
        foreach (char c in text)
        {
            if (!(c >= 'A' && c <= 'Z') &&
                !(c >= 'a' && c <= 'z') &&
                !(c >= '0' && c <= '9') &&
                !char.IsWhiteSpace(c))
            {
                return false;}}
        return true;}
    static string ReadNonEmptyString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ошибка! Строка не может быть пустой.");
                continue;}
            if (!IsEnglish(input))
            {
                Console.WriteLine("Ошибка! Используйте только английские буквы и цифры.");
                continue;}
            return input;}}
    static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= 0)
                return value;
            Console.WriteLine("Ошибка! Введите целое число (0 или больше).");}}
    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
                return value;
            Console.WriteLine("Ошибка! Введите целое число.");}}
    static void AddTask()
    {
        string title = ReadNonEmptyString("Введите название задачи (английский): ");
        int priority = ReadNonNegativeInt("Введите приоритет (0 или больше): ");

        SaveState();
        tasks.Add(new TaskItem(nextId++, title, priority));
        Console.WriteLine("Задача добавлена.");}
    static void RemoveTask()
    {
        int id = ReadInt("Введите ID задачи для удаления: ");

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                SaveState();
                tasks.RemoveAt(i);
                Console.WriteLine("Задача удалена.");
                return;}}
        Console.WriteLine("Задача не найдена.");}
    static void ChangePriority()
    {
        int id = ReadInt("Введите ID задачи: ");
        int newPriority = ReadNonNegativeInt("Введите новый приоритет: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                SaveState();
                tasks[i].Priority = newPriority;
                Console.WriteLine("Приоритет изменён.");
                return;}}
        Console.WriteLine("Задача не найдена.");}
    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;}
        foreach (var task in tasks)
        {
            Console.WriteLine(task);}}
    static void ExecuteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Нет задач для выполнения.");
            return;}
        List<TaskItem> sorted = new List<TaskItem>(tasks);
        sorted.Sort((a, b) => a.Priority.CompareTo(b.Priority));
        TaskItem task = sorted[0];
        SaveState();
        tasks.RemoveAll(t => t.Id == task.Id);
        Console.WriteLine($"Задача: {task} выполнена!");}
    static void Undo()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Нет изменений для отката.");
            return;}
        tasks = history.Pop();
        Console.WriteLine("Последнее изменение отменено.");}}
