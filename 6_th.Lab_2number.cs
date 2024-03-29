using System;

class Human
{
    private string Name { get; set; }
    private int MathGrade { get; set; }
    private int PhysicsGrade { get; set; }
    private int RussianGrade { get; set; }

    public Human(string name, int mathGrade, int physicsGrade, int russianGrade)
    {
        Name = name;
        MathGrade = mathGrade;
        PhysicsGrade = physicsGrade;
        RussianGrade = russianGrade;
    }

    private double AverageGrade()
    {
        return (MathGrade + PhysicsGrade + RussianGrade) / 3.0;
    }

    public string GetName()
    {
        return Name;
    }

    public double GetAverageGrade()
    {
        return AverageGrade();
    }
}

class Student : Human
{
    private int StudentId { get; set; }

    public Student(string name, int id, int studentId, int mathGrade, int physicsGrade, int russianGrade)
        : base(name, mathGrade, physicsGrade, russianGrade)
    {
        StudentId = studentId;
    }

    public int GetId()
    {
        return StudentId;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[8];
        students[0] = new Student("Alice", 1, 1001, 5, 4, 5);
        students[1] = new Student("Bob", 2, 1002, 4, 3, 4);
        students[2] = new Student("Karl", 3, 1003, 3, 5, 4);
        students[3] = new Student("David", 4, 1004, 5, 3, 4);
        students[4] = new Student("Eve", 5, 1005, 4, 5, 3);
        students[5] = new Student("Emma", 6, 1006, 5, 5, 5);
        students[6] = new Student("Alex", 7, 1007, 2, 3, 5);
        students[7] = new Student("Lili", 8, 1008, 3, 2, 4);

        Console.WriteLine("ФИО\t ИД \t Средний балл");

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine("{0} \t {1} \t {2:f2}", students[i].GetName(), students[i].GetId(), students[i].GetAverageGrade());
        }

        Console.ReadKey();
    }
}