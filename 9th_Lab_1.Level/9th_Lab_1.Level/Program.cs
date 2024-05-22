using lab_9.Serializers;
using ProtoBuf;
using System;
using System.Xml.Serialization;
[XmlInclude(typeof(MathStudent))]
[XmlInclude(typeof(InformaticsStudent))]
[ProtoInclude(4, typeof(MathStudent))]
[ProtoInclude(5, typeof(InformaticsStudent))]
[Serializable, ProtoContract]
public abstract class Student
{
    protected string name;
    protected int grade;
    protected int missedClasses;
    [ProtoMember(1)]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    [ProtoMember(2)]
    public int Grade { get { return grade; } set { grade = value; } }
    [ProtoMember(3)]
    public int MissedClasses { get { return missedClasses; } set { missedClasses = value; } }
    public Student() { }

    public Student(string name, int grade, int missedClasses)
    {
        this.name = name;
        this.grade = grade;
        this.missedClasses = missedClasses;
    }

    public abstract void Print();
}
[ ProtoContract]
public class InformaticsStudent : Student
{
    public InformaticsStudent() { }
    public InformaticsStudent(string name, int grade, int missedClasses) : base(name, grade, missedClasses)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Фамилия {0} \t {1} балл \t кол-во пропусков {2}", name, grade, missedClasses);
    }
}
[ProtoContract]
public class MathStudent : Student
{
    public MathStudent() { }    
    public MathStudent(string name, int grade, int missedClasses) : base(name, grade, missedClasses)
    {
    }

    public override void Print()
    {
        Console.WriteLine("Фамилия {0} \t {1} балл \t кол-во пропусков {2}", name, grade, missedClasses);
    }
}

public class Program
{
    public static void Main(string[] args)
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

        string DirName = "9th lab 1";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, DirName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string[] filesName =
        {
            "mathstudents.json",
            "mathStudents.xml",
            "matStudents.bin",
            "informaticsStudents.json",
            "informaticsStudents.xml",
            "informaticsStudents.bin"
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
            Ser[i].Write(mathStudents, Path.Combine(path, filesName[i]));
            Ser[i].Write(informaticsStudents, Path.Combine(path, filesName[i+3]));
        }


        Console.WriteLine("Студенты по информатике:");
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(serNames[i]);
            var p1 = Ser[i].Read<InformaticsStudent[]>(Path.Combine(path, filesName[i + 3]));
            foreach (var p in p1)
            {
                p.Print();
            }
        }
     

        Console.WriteLine("\nСтуденты по математике:");
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(serNames[i]);
            var p1 = Ser[i].Read<MathStudent[]>(Path.Combine(path, filesName[i]));
            foreach (var p in p1)
            {
                p.Print();
            }
        }



    }
}
