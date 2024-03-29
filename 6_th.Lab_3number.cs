using System;

class Team
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Team(string name, int points)
    {
        Name = name;
        Points = points;
    }
    public virtual void Print(int place)
    {
        Console.WriteLine("{0}.  {1}   {2} баллов", place, Name, Points);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Team[] womenTeams = new Team[7]
        {
            new Team("женская Team1 ", 26),
            new Team("женская Team2 ", 21),
            new Team("женская Team3 ", 19),
            new Team("женская Team4 ", 16),
            new Team("женская Team5 ", 25),
            new Team("женская Team6 ", 15),
            new Team("женская Team7 ", 17)
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

        Console.WriteLine("Топ 12 команд:");
        for (int i = 0; i < 12; i++)
        {
            topTeams[i].Print(i + 1);
        }

        Console.ReadKey();
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