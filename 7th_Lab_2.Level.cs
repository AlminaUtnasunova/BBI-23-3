using System;

class Human
{
    private static int nextId = 1001;
    private int _studentId;
    protected string _name;
    protected int _mathGrade;
    protected int _physicsGrade;
    protected int _russianGrade;

    public Human(string name, int mathGrade, int physicsGrade, int russianGrade)
    {
        _name = name;
        _mathGrade = mathGrade;
        _physicsGrade = physicsGrade;
        _russianGrade = russianGrade;
        _studentId = nextId;
        nextId++;
    }

    protected virtual double AverageGrade()
    {
        return (_mathGrade + _physicsGrade + _russianGrade) / 3.0;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine("Name: {0}, Student ID: {1}, Average Grade: {2:f2}", _name, StudentId, AverageGrade());
    }

    public int StudentId { get { return _studentId; } }
}

class Student : Human
{
    public Student(string name, int mathGrade, int physicsGrade, int russianGrade)
        : base(name, mathGrade, physicsGrade, russianGrade)
    {
    }

    protected override double AverageGrade()
    {
        return (_mathGrade + _physicsGrade + _russianGrade) / 3.0;
    }

    public override void PrintInfo()
    {
        Console.WriteLine("Name: {0}, ID: {1}, Average Grade: {2:f2}", _name, StudentId, AverageGrade());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[8];
        students[0] = new Student("Alice", 5, 4, 5);
        students[1] = new Student("Bob", 4, 3, 4);
        students[2] = new Student("Karl", 3, 5, 4);
        students[3] = new Student("David", 5, 3, 4);
        students[4] = new Student("Eve", 4, 5, 3);
        students[5] = new Student("Emma", 5, 5, 5);
        students[6] = new Student("Alex", 2, 3, 5);
        students[7] = new Student("Lili", 3, 2, 4);

        for (int i = 0; i < students.Length; i++)
        {
            students[i].PrintInfo();
        }

        Console.ReadKey();
    }
}
