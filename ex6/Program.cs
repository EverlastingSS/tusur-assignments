using System;
using System.Collections.Generic;
// zadanie 2
struct TaskItem
{
    public int Id;
    public string Title;
    public int Priority;

    public TaskItem(int id, string title, int priority)
    {
        Id = id;
        Title = title;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Название: {Title}, Приоритет: {Priority}";
    }
}

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
                default: Console.WriteLine("Неверный выбор."); break;
            }
        }
    }

    static void SaveState()
    {
        history.Push(new List<TaskItem>(tasks));
    }

    static void AddTask()
    {
        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine();

        Console.Write("Введите приоритет (меньше = важнее): ");
        int priority = int.Parse(Console.ReadLine());

        SaveState();
        tasks.Add(new TaskItem(nextId++, title, priority));

        Console.WriteLine("Задача добавлена.");
    }

    static void RemoveTask()
    {
        Console.Write("Введите ID задачи для удаления: ");
        int id = int.Parse(Console.ReadLine());

        SaveState();
        tasks.RemoveAll(t => t.Id == id);

        Console.WriteLine("Задача удалена (если существовала).");
    }

    static void ChangePriority()
    {
        Console.Write("Введите ID задачи: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Введите новый приоритет: ");
        int newPriority = int.Parse(Console.ReadLine());

        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == id)
            {
                SaveState();
                tasks[i] = new TaskItem(tasks[i].Id, tasks[i].Title, newPriority);
                Console.WriteLine("Приоритет изменён.");
                return;
            }
        }

        Console.WriteLine("Задача не найдена.");
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    static void ExecuteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Нет задач для выполнения.");
            return;
        }

        // копия списка
        List<TaskItem> sorted = new List<TaskItem>(tasks);

        // по приоритету
        sorted.Sort((a, b) =>
        {
            if (a.Priority < b.Priority) return -1;
            if (a.Priority > b.Priority) return 1;
            return 0;
        });

        TaskItem task = sorted[0]; // первая -- самая приоритетная

        SaveState();
        tasks.RemoveAll(t => t.Id == task.Id);

        Console.WriteLine($"Задача: {task} выполнена!");
    }


    static void Undo()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("Нет изменений для отката.");
            return;
        }

        tasks = history.Pop();
        Console.WriteLine("Последнее изменение отменено.");
    }
}
