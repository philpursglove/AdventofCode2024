var input = File.ReadAllLines("InputFile.txt");

List<Report> reports = new List<Report>();

foreach (var line in input)
{
    reports.Add(new Report(line));
}

Console.WriteLine(reports.Count(r => r.Safe));
Console.ReadLine();

Console.WriteLine(reports.Count(r => r.SafeAfterDampening()));
Console.ReadLine();

public class Report
{
    public Report(string line)
    {
        Levels = new List<int>();

        var elements = line.Split(" ");

        foreach (var element in elements)
        {
            Levels.Add(int.Parse(element));
        }
    }

    public Report(List<int> newLevels)
    {
        Levels = newLevels;
    }

    public List<int> Levels { get; set; }

    public bool AllAscending()
    {
        var elements = Levels.ToArray();

        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            if (elements[i + 1] <= elements[i]) return false;
        }

        return true;
    }

    public bool AllDescending()
    {
        var elements = Levels.ToArray();

        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            if (elements[i + 1] >= elements[i]) return false;
        }

        return true;
    }

    private bool HasGaps()
    {
        var elements = Levels.ToArray();

        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            var diff = Math.Abs(elements[i] - elements[i + 1]);

            if (diff < 1 || diff > 3)
            {
                return true;
            }
        }

        return false;
    }



    public bool Safe => (AllAscending() || AllDescending()) && !HasGaps();

    public bool SafeAfterDampening()
    {
        List<Report> DampenedReports = new List<Report>();

        for (int i = 0; i < Levels.Count; i++)
        {
            var newLevels = new List<int>(Levels);
            newLevels.RemoveAt(i);
            DampenedReports.Add(new Report(newLevels));
        }

        return DampenedReports.Any(r => r.Safe);
    }
}