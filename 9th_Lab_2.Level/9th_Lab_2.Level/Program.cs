using lab_9.Serializers;
using ProtoBuf;
using System;
using System.Xml.Serialization;
[XmlInclude (typeof(Student))]
[ProtoInclude (6, typeof(Student))]
[Serializable, ProtoContract]
public class Human
{
    private static int nextId = 1001;
    private int _studentId;
    protected string _name;
    protected int _mathGrade;
    protected int _physicsGrade;
    protected int _russianGrade;

    [ProtoMember (1)]
    public int StudentId { get { return _studentId; } set { _studentId = value; } }
    [ProtoMember (2)]
    public string Name { get { return _name; } set { _name = value; } }
    [ProtoMember (3)]
    public int MathGrade { get { return _mathGrade; } set { _mathGrade = value; } }
    [ProtoMember (4)]
    public int PhysicsGrade { get { return _physicsGrade; } set { _physicsGrade = value; } }
    [ProtoMember (5)]
    public int RussianGrade { get { return _russianGrade; } set { _russianGrade = value; } }
    public Human() { }
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

}
[ProtoContract]
public class Student : Human
{
    public Student() { }
    public Student(string name, int mathGrade, int physicsGrade, int russianGrade): base(name, mathGrade, physicsGrade, russianGrade){}

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

       

        
        string DirName = "9th lab 2";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, DirName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string[] filesName =
        {
            "students.json",
            "students.xml",
            "students.bin"
        };
        string[] serNames =
        {
            "Json ser",
            "XML Ser",
            "Bin ser"
        };
        MySer[] Ser =
        {
            new MyJsonSerilazer(),
            new MyXmlSer(),
            new MyBinSer()
        };
        for (int i = 0; i < Ser.Length; i++)
        {
            Ser[i].Write(students, Path.Combine(path, filesName[i]));
        }


        Console.WriteLine("Студенты");
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(serNames[i]);
            var p1 = Ser[i].Read<Student[]>(Path.Combine(path, filesName[i]));
            foreach (var p in p1)
            {
                p.PrintInfo();
            }
        }


       
    }
}
