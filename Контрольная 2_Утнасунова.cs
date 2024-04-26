
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string Text = "Hello students ;)";
        Task[] tasks = { new Task1(Text), new Task2(Text) };
        Console.WriteLine(tasks[0].CalculateMaxCount());
        Console.WriteLine(((Task2)tasks[1]).AreBracketsBalanced());

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string solutionFolder = Path.Combine(folderPath, "Solution");

        if (!Directory.Exists(solutionFolder))
        {
            Directory.CreateDirectory(solutionFolder);
        }

        string task1FilePath = Path.Combine(solutionFolder, "task_1.json");
        string task2FilePath = Path.Combine(solutionFolder, "task_2.json");

        if (!File.Exists(task1FilePath))
        {
            File.Create(task1FilePath).Close();
        }

        if (!File.Exists(task2FilePath))
        {
            File.Create(task2FilePath).Close();
        }
    }
}

abstract class Task
{
    protected string Text;

    public Task(string text)
    {
        Text = text;
    }

    public abstract int CalculateMaxCount();
}

class Task1 : Task
{
    public Task1(string text) : base(text) { }

    public override int CalculateMaxCount()
    {
        int maxCount = 0;
        int currentCount = 1;
        char previousChar = Text[0];

        for (int i = 1; i < Text.Length; i++)
        {
            if (Text[i] == previousChar)
            {
                currentCount++;
            }
            else
            {
                maxCount = Math.Max(maxCount, currentCount);
                currentCount = 1;
                previousChar = Text[i];
            }
        }

        maxCount = Math.Max(maxCount, currentCount);
        return maxCount;
    }
}

class Task2 : Task
{
    public Task2(string text) : base(text) { }

    public override int CalculateMaxCount()
    {
        return 0;
    }

    public bool AreBracketsBalanced()
    {
        Stack<char> brackets = new Stack<char>();

        foreach (char c in Text)
        {
            if (IsOpeningBracket(c))
            {
                brackets.Push(c);
            }
            else if (IsClosingBracket(c))
            {
                if (brackets.Count == 0 || !IsMatchingPair(brackets.Pop(), c))
                {
                    return false;
                }
            }
        }

        return brackets.Count == 0;
    }

    private bool IsOpeningBracket(char c)
    {
        return c == '(' || c == '[' || c == '{';
    }

    private bool IsClosingBracket(char c)
    {
        return c == ')' || c == ']' || c == '}';
    }

    private bool IsMatchingPair(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '[' && closing == ']') ||
               (opening == '{' && closing == '}');
    }
}