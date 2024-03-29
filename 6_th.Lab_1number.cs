using System;

abstract class Student
{
    protected string name;
    protected int grade;
    protected int missedClasses;

    public string Name => name;
    public int Grade => grade;
    public int MissedClasses => missedClasses;

    public Student(string name, int grade, int missedClasses)
    {
        this.name = name;
        this.grade = grade;
        this.missedClasses = missedClasses;
    }

    public abstract void Print();
}

class InformaticsStudent : Student
{
    public InformaticsStudent(string name, int grade, int missedClasses) : base(name, grade, missedClasses)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Фамилия {0} \t {1} балл \t кол-во пропусков {2}", name, grade, missedClasses);
    }
}

class MathStudent : Student
{
    public MathStudent(string name, int grade, int missedClasses) : base(name, grade, missedClasses)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Фамилия {0} \t {1} балл \t кол-во пропусков {2}", name, grade, missedClasses);
    }
}

class Program
{
    static void Main(string[] args)
    {
        InformaticsStudent[] informaticsStudents = new InformaticsStudent[8];
        informaticsStudents[0] = new InformaticsStudent("Alice", 2, 3);
        informaticsStudents[1] = new InformaticsStudent("Bob", 4, 5);
        informaticsStudents[2] = new InformaticsStudent("Karl", 2, 7);
        informaticsStudents[3] = new InformaticsStudent("David", 3, 1);
        informaticsStudents[4] = new InformaticsStudent("Eve", 2, 6);
        informaticsStudents[5] = new InformaticsStudent("Emma", 4, 2);
        informaticsStudents[6] = new InformaticsStudent("Alex", 3, 4);
        informaticsStudents[7] = new InformaticsStudent("Lili", 2, 5);

        MathStudent[] mathStudents = new MathStudent[8];
        mathStudents[0] = new MathStudent("George", 5, 2);
        mathStudents[1] = new MathStudent("Helen", 4, 4);
        mathStudents[2] = new MathStudent("Ivan", 2, 6);
        mathStudents[3] = new MathStudent("Karen", 3, 1);
        mathStudents[4] = new MathStudent("Luke", 2, 5);
        mathStudents[5] = new MathStudent("Mary", 5, 3);
        mathStudents[6] = new MathStudent("Nancy", 4, 2);
        mathStudents[7] = new MathStudent("Oscar", 2, 7);

        Console.WriteLine("Студенты по информатике:");
        for (int i = 0; i < informaticsStudents.Length; i++)
        {
            informaticsStudents[i].Print();
        }

        Console.WriteLine("\nСтуденты по математике:");
        for (int i = 0; i < mathStudents.Length; i++)
        {
            mathStudents[i].Print();
        }

        Console.ReadKey();
    }
}