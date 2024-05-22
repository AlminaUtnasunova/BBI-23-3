using lab_9.Serializers;
using ProtoBuf;
using System;
using System.Xml.Serialization;
[ProtoContract]
public class Team
{
    private string name;
    private int points;
    [ProtoMember(1)]
    public string Name {  get { return name; } set { name = value; } }
    [ProtoMember(2)]
    public int Points { get { return points; } set { points = value; } }
    public Team() { }

    public Team(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

   

    public virtual void Print(int place)
    {
        Console.WriteLine("{0}. {1} команда {2} баллов", place, Name, Points);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Team[] womenTeams = new Team[7]
        {
            new Team("женская Team1", 26),
            new Team("женская Team2", 21),
            new Team("женская Team3", 19),
            new Team("женская Team4", 16),
            new Team("женская Team5", 25),
            new Team("женская Team6", 15),
            new Team("женская Team7", 17)
        };
        SortTeams(womenTeams);

        Team[] menTeams = new Team[7]
        {
            new Team("мужская Team8", 18),
            new Team("мужская Team9", 23),
            new Team("мужская Team10", 20),
            new Team("мужская Team11", 16),
            new Team("мужская Team12", 24),
            new Team("мужская Team13", 22),
            new Team("мужская Team14", 28)
        };
        SortTeams(menTeams);

        Team[] topTeams = new Team[12];

        int womenIndex = 0;
        int menIndex = 0;

        for (int i = 0; i < topTeams.Length; i++)
        {
            if (i < 6)
            {
                topTeams[i] = womenTeams[womenIndex];
                womenIndex++;
            }
            else
            {
                topTeams[i] = menTeams[menIndex];
                menIndex++;
            }
        }

        SortTeams(topTeams);

     
     

        string DirName = "9th lab 3";
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        path = Path.Combine(path, DirName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string[] filesName =
        {
            "topTeams.json",
            "topTeams.xml",
            "topTeams.bin",
            
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
            Ser[i].Write(topTeams, Path.Combine(path, filesName[i]));
         
        }


        Console.WriteLine("Топ 12 команд:");
        for (int i = 0; i < Ser.Length; i++)
        {
            Console.WriteLine(serNames[i]);
            var p1 = Ser[i].Read<Team[]>(Path.Combine(path, filesName[i]));
            int k = 1;
            foreach (var p in p1)
            {
                p.Print(k++);
            }
           
        }
    }

    static void SortTeams(Team[] teams)
    {
        for (int i = 0; i < teams.Length; i++)
        {
            for (int j = i + 1; j < teams.Length; j++)
            {
                if (teams[j].Points > teams[i].Points)
                {
                    Team temp = teams[j];
                    teams[j] = teams[i];
                    teams[i] = temp;
                }
            }
        }
    }
}
